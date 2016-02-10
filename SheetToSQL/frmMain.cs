using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SheetToSQL
{
	public partial class frmMain : Form
	{
		public enum BlankBehaviorOption { Null = 0, BlankString = 1 }
		public static readonly string[] BlankBehaviorStr = new string[] { "[NULL]", "[BLANK STRING]" };

		private int pnlFileWidthDiff;
		private int pnlFileHeightDiff;
		private int lstColumnsHeightDiff;
		private int pnlColumnHeightDiff;
		private int lblHeaderNameWidthDiff;
		private int pnlSettingsHeightDiff;
		private int pnlSettingsWidthDiff;
		private int txtSQLFirstLineWidthDiff;
		private int txtSQLRecurHeightDiff;
		private string activeFile;
		private string activeFileExtension;
		public BlankBehaviorOption[] blankBehavior;
		private int curIndex;
		private int numRows;

		// lstColumns formatting
		private readonly Color colExcludeColor = Color.Black;
		private Font colExcludeFont = null;

		// Excel fields
		private Excel.Application xlApp;
		private Excel.Workbook xlWorkBook;
		private Excel.Worksheet xlWorkSheet;
		private Excel.Range xlRange;
		private int excelRowCount;
		private int excelColCount;
		private int excelCurLine;

		// CSV fields
		private StreamReader csvReader;

		public frmMain()
		{
			InitializeComponent();

			colExcludeFont = lstColumns.Font;
		}

		private string clear()
		{
			string errorMessage = string.Empty;

			activeFile = null;
			activeFileExtension = null;
			blankBehavior = null;
			curIndex = -1;
			numRows = 0;
			xlApp = null;
			xlWorkBook = null;
			xlWorkSheet = null;
			xlRange = null;
			excelColCount = -1;
			excelRowCount = -1;
			excelCurLine = -1;

			csvReader = null;

			lblHeaderName.Text = string.Empty;
			pnlFile.Enabled = false;
			lstColumns.ClearSelected();
			lstColumns.Items.Clear();
			pnlColumn.Enabled = false;
			lblProgress.Text = string.Empty;

			cmbBlankBehavior.SelectedIndex = 0;

			txtSQLRecur.Text = string.Empty;

			return errorMessage;
		}

		private void storeCurColVals()
		{
			if (curIndex != -1)
				blankBehavior[curIndex] = (BlankBehaviorOption)cmbBlankBehavior.SelectedIndex;
		}

		private string validate()
		{
			string errorMessage = string.Empty;

			storeCurColVals();

			return errorMessage;
		}

		#region Events

		private void frmMain_Load(object sender, EventArgs e)
		{
			string errorMessage = string.Empty;
			
			this.MinimumSize = this.Size;
			pnlFileWidthDiff = this.Width - pnlFile.Width;
			pnlFileHeightDiff = this.Height - pnlFile.Height;
			lstColumnsHeightDiff = pnlFile.Height - lstColumns.Height;
			pnlColumnHeightDiff = pnlFile.Height - pnlColumn.Height;
			lblHeaderNameWidthDiff = pnlColumn.Width - lblHeaderName.Width;
			pnlSettingsHeightDiff = pnlFile.Height - pnlSettings.Height;
			pnlSettingsWidthDiff = this.Width - pnlSettings.Width;
			txtSQLFirstLineWidthDiff = pnlSettings.Width - txtSQLFirstLine.Width;
			txtSQLRecurHeightDiff = pnlSettings.Height - txtSQLRecur.Height;

			cmbBlankBehavior.Items.Clear();
			foreach (string item in BlankBehaviorStr)
			{
				cmbBlankBehavior.Items.Add(item);
			}

			errorMessage += clear();

			if (!string.IsNullOrEmpty(errorMessage))
				MessageBox.Show(this, errorMessage, "SheetToSQL");
		}

		private void frmMain_Resize(object sender, EventArgs e)
		{
			pnlFile.Width = this.Width - pnlFileWidthDiff;
			pnlFile.Height = this.Height - pnlFileHeightDiff;
			lstColumns.Height = (int)(((double)(pnlFile.Height - lstColumnsHeightDiff) / (double)lstColumns.ItemHeight) * (double)lstColumns.ItemHeight);
			pnlColumn.Height = pnlFile.Height - pnlColumnHeightDiff;
			lblHeaderName.Width = pnlColumn.Width - lblHeaderNameWidthDiff;
			pnlSettings.Height = pnlFile.Height - pnlSettingsHeightDiff;
			pnlSettings.Width = this.Width - pnlSettingsWidthDiff;
			txtSQLFirstLine.Width = pnlSettings.Width - txtSQLFirstLineWidthDiff;
			txtSQLRecur.Width = txtSQLFirstLine.Width;
			txtSQLRecur.Height = pnlSettings.Height - txtSQLRecurHeightDiff;
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			string errorMessage = string.Empty;
			if (dlgOpen.ShowDialog().ToString().Equals("OK"))
			{
				errorMessage += clear();

				activeFile = dlgOpen.FileName;
				activeFileExtension = activeFile.Substring(activeFile.LastIndexOf('.'));
				string[] headers = null;
				errorMessage += getHeaders(out headers);

				if (string.IsNullOrEmpty(errorMessage))
				{
					blankBehavior = new BlankBehaviorOption[headers.Length];
					for (int i = 0; i < headers.Length; i++)
					{
						lstColumns.Items.Add(i.ToString() + ". " + headers[i]);
						blankBehavior[i] = BlankBehaviorOption.Null;
					}

					pnlFile.Enabled = true;
				}

				lblProgress.Text = numRows.ToString() + " rows";
			}

			if (!string.IsNullOrEmpty(errorMessage))
				MessageBox.Show(this, errorMessage, "SheetToSQL");
		}

		private void btnSaveAs_Click(object sender, EventArgs e)
		{
			string errorMessage = string.Empty;

			errorMessage += validate();

			if (string.IsNullOrEmpty(errorMessage) && dlgSaveAs.ShowDialog().ToString().Equals("OK"))
			{
				btnOpen.Enabled = false;
				pnlFile.Enabled = false;
				string saveAsText = btnSaveAs.Text;
				btnSaveAs.Text = "Saving...";

				TextWriter writer = null;

				List<int> strIndexes = new List<int>();
				List<int> colIndexes = new List<int>();
				List<string> strSections = new List<string>();

				for (int i = 0; i < blankBehavior.Length; i++)
				{
					int from = 0;
					string lookFor = "{" + i + "}";

					int index = 0;
					while ((index = txtSQLRecur.Text.IndexOf(lookFor, from)) != -1)
					{
						strIndexes.Add(index);
						colIndexes.Add(i);
						from = index + lookFor.Length;
					}
				}

				// sort them
				bool changed = true;
				while (changed)
				{
					changed = false;

					for (int i = 1; i < strIndexes.Count; i++)
					{
						if (strIndexes[i] < strIndexes[i - 1])
						{
							changed = true;
							int a = strIndexes[i];
							int b = colIndexes[i];
							strIndexes[i] = strIndexes[i - 1];
							colIndexes[i] = colIndexes[i - 1];
							strIndexes[i - 1] = a;
							colIndexes[i - 1] = b;
						}
					}
				}

				// create sections
				int start = 0;
				for (int i = 0; i < strIndexes.Count; i++)
				{
					strSections.Add(txtSQLRecur.Text.Substring(start, strIndexes[i] - start));
					start = strIndexes[i] + colIndexes[i].ToString().Length + 2;
				}

				if (start < txtSQLRecur.Text.Length)
					strSections.Add(txtSQLRecur.Text.Substring(start));

				try
				{
					errorMessage += openFile();
					writer = new StreamWriter(dlgSaveAs.FileName);

					if (!string.IsNullOrWhiteSpace(txtSQLFirstLine.Text))
						writer.WriteLine(txtSQLFirstLine.Text);

					// get the headers out of the way...
					getNextLine();

					int row = 0;
					string[] line = getNextLine();
					StringBuilder statement = new StringBuilder();
					while (line != null)
					{
						row++;
						if (row % 10 == 0)
							lblProgress.Text = "Processing row " + row.ToString() + " / " + numRows.ToString();

						statement.Clear();

						for (int i = 0; i < strIndexes.Count; i++)
						{
							statement.Append(strSections[i]);

							string val = null;
							int col = colIndexes[i];

							if (string.IsNullOrEmpty(line[col]))
							{
								switch (blankBehavior[col])
								{
									case BlankBehaviorOption.BlankString:
										val = "''";
										break;
									case BlankBehaviorOption.Null:
										val = "NULL";
										break;
								}
							}
							else
							{
								val = "'" + line[col].Replace("'", @"\'") + "'";
							}

							statement.Append(val);
						}

						if (strSections.Count > strIndexes.Count)
							statement.Append(strSections[strSections.Count - 1]);

						writer.WriteLine(statement);

						line = getNextLine();
					}


				}
				catch (Exception ex)
				{
					errorMessage += "Error writing sql to file: " + ex.Message + "\n\n";
				}
				finally
				{
					if (writer != null)
						writer.Close();

					errorMessage += releaseObjs();
				}

				lblProgress.Text = numRows.ToString() + " rows";

				btnOpen.Enabled = true;
				pnlFile.Enabled = true;
				btnSaveAs.Text = saveAsText;

				if (string.IsNullOrEmpty(errorMessage))
					MessageBox.Show(this, "Script successfully saved to \"" + dlgSaveAs.FileName + "\".");
			}

			if (!string.IsNullOrEmpty(errorMessage))
				MessageBox.Show(this, errorMessage, "SheetToSQL");
		}

		private void lstColumns_SelectedIndexChanged(object sender, EventArgs e)
		{
			string errorMessage = string.Empty;

			storeCurColVals();

			if (string.IsNullOrEmpty(errorMessage))
			{
				curIndex = lstColumns.SelectedIndex;

				if (curIndex != -1)
				{
					lblHeaderName.BackColor = System.Drawing.SystemColors.ActiveCaption;
					lblHeaderName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
					lblHeaderName.Text = (string)lstColumns.SelectedItem;

					cmbBlankBehavior.SelectedIndex = (int)blankBehavior[curIndex];

					pnlColumn.Enabled = true;
				}
				else
				{
					lblHeaderName.BackColor = System.Drawing.SystemColors.InactiveCaption;
					lblHeaderName.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
					lblHeaderName.Text = string.Empty;

					cmbBlankBehavior.SelectedIndex = 0;

					pnlColumn.Enabled = false;
				}
			}

			if (!string.IsNullOrEmpty(errorMessage))
				MessageBox.Show(this, errorMessage, "SheetToSQL");
		}

		private void lstColumns_DrawItem(object sender, DrawItemEventArgs e)
		{
			Color colColor;
			Font colFont = null;
			string postFix = null;

			colColor = colExcludeColor;
			colFont = colExcludeFont;
			postFix = string.Empty;

			e.DrawBackground();

			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
				colColor = System.Drawing.SystemColors.ActiveCaptionText;

			// draw text
			e.Graphics.DrawString(lstColumns.Items[e.Index].ToString(), colFont, new SolidBrush(colColor), e.Bounds);

			// draw postfix
			if (!string.IsNullOrEmpty(postFix))
				e.Graphics.DrawString(postFix, lstColumns.Font, new SolidBrush(colColor), e.Graphics.MeasureString(lstColumns.Items[e.Index].ToString(), lstColumns.Font).Width, e.Bounds.Y);
		}

		#endregion Events

		#region Reader Methods

		private string getHeaders(out string[] headers)
		{
			string errorMessage = string.Empty;
			headers = null;

			switch (activeFileExtension)
			{
				case ".xlsx":
					errorMessage += getExcelHeaders(out headers);
					break;
				case ".csv":
					errorMessage += getCSVHeaders(out headers);
					break;
				default:
					errorMessage += "Unrecognized file extension: " + activeFileExtension + "\n\n";
					break;
			}

			return errorMessage;
		}

		private string[] getNextLine()
		{
			string[] line = null;

			switch (activeFileExtension)
			{
				case ".xlsx":
					line = getNextExcelLine();
					break;
				case ".csv":
					line = getNextCSVLine();
					break;
				default:
					throw new Exception("Unrecognized file extension: " + activeFileExtension);
			}

			return line;
		}

		private string openFile()
		{
			string errorMessage = string.Empty;

			switch (activeFileExtension)
			{
				case ".xlsx":
					errorMessage += openExcelFile();
					break;
				case ".csv":
					errorMessage += openCSVFile();
					break;
				default:
					errorMessage += "Unrecognized file extension: " + activeFileExtension + "\n\n";
					break;
			}

			return errorMessage;
		}

		private string releaseObjs()
		{
			string errorMessage = string.Empty;

			switch (activeFileExtension)
			{
				case ".xlsx":
					errorMessage += releaseExcelObjs();
					break;
				case ".csv":
					errorMessage += releaseCSVObjs();
					break;
				default:
					errorMessage += "Unrecognized file extension: " + activeFileExtension + "\n\n";
					break;
			}

			return errorMessage;
		}

		#endregion Reader Methods

		#region Excel Methods

		private string getExcelHeaders(out string[] headers)
		{
			string errorMessage = string.Empty;

			errorMessage += openExcelFile();

			if (string.IsNullOrEmpty(errorMessage))
				headers = getNextExcelLine();
			else
				headers = null;

			errorMessage += releaseExcelObjs();

			return errorMessage;
		}

		private string[] getNextExcelLine()
		{
			excelCurLine++;

			if (excelCurLine > excelRowCount)
				return null;

			string[] cells = new string[excelColCount];

			for (int i = 1; i <= excelColCount; i++)
			{
				if (xlRange.Cells[excelCurLine, i] == null || xlRange.Cells[excelCurLine, i].Value2 == null)
					cells[i - 1] = string.Empty;
				else
					cells[i - 1] = xlRange.Cells[excelCurLine, i].Value2.ToString();
			}

			return cells;
		}

		private string openExcelFile()
		{
			string errorMessage = string.Empty;

			try
			{
				xlApp = new Excel.Application();
				xlWorkBook = xlApp.Workbooks.Open(activeFile);
				xlWorkSheet = xlWorkBook.Sheets[1];
				xlRange = xlWorkSheet.UsedRange;
				excelColCount = xlRange.Columns.Count;
				excelRowCount = xlRange.Rows.Count;
				excelCurLine = 0;
			}
			catch (Exception ex)
			{
				xlApp = null;
				xlWorkBook = null;
				xlWorkSheet = null;
				xlRange = null;
				excelColCount = -1;
				excelRowCount = -1;
				excelCurLine = -1;

				errorMessage += "Error opening Excel file: " + ex.Message + "\n\n";
			}

			numRows = excelRowCount - 1;

			return errorMessage;
		}

		private string releaseExcelObjs()
		{
			string errorMessage = string.Empty;

			try
			{
				//cleanup
				GC.Collect();
				GC.WaitForPendingFinalizers();

				//rule of thumb for releasing com objects:
				//  never use two dots, all COM objects must be referenced and released individually
				//  ex: [somthing].[something].[something] is bad

				//release com objects to fully kill excel process from running in the background
				Marshal.ReleaseComObject(xlRange);
				Marshal.ReleaseComObject(xlWorkSheet);

				//close and release
				xlWorkBook.Close();
				Marshal.ReleaseComObject(xlWorkBook);

				//quit and release
				xlApp.Quit();
				Marshal.ReleaseComObject(xlApp);
			}
			catch (Exception ex)
			{
				errorMessage += "Error releasing Excel objects: " + ex.Message + "\n\n";
			}

			xlApp = null;
			xlWorkBook = null;
			xlWorkSheet = null;
			xlRange = null;
			excelColCount = -1;
			excelRowCount = -1;
			excelCurLine = -1;

			return errorMessage;
		}

		#endregion Excel Methods

		#region CSV Methods

		private string getCSVHeaders(out string[] headers)
		{
			string errorMessage = string.Empty;

			openCSVFile();

			if (string.IsNullOrEmpty(errorMessage))
				headers = getNextCSVLine();
			else
				headers = null;

			errorMessage += releaseCSVObjs();

			return errorMessage;
		}

		private string[] getNextCSVLine()
		{
			const char encloser = '"';
			const char separator = ',';
			const string connector = "\n";
			bool complete = false;
			string[] fields = null;
			string line = csvReader.ReadLine();

			while (!complete && line != null)
			{
				string[] temp;

				if (!(complete = parseCSV(line, separator, encloser, out temp)))
					line = encloser.ToString() + csvReader.ReadLine(); // start with an encloser so that the parser isn't confused

				fields = (fields != null) ? concatStrArrays(fields, temp, connector) : temp;
			}

			int lastField = (fields != null) ? fields.Length - 1 : -1;

			if (!complete && lastField != -1 && fields[lastField].Length > 0)
				fields[lastField] = fields[lastField].Substring(1);

			return fields;
		}

		private string openCSVFile()
		{
			string errorMessage = string.Empty;

			try
			{
				int lineCount = File.ReadLines(activeFile).Count() - 1;
				csvReader = new StreamReader(activeFile);
			}
			catch (Exception ex)
			{
				csvReader = null;

				errorMessage += "Error opening CSV file: " + ex.Message + "\n\n";
			}

			return errorMessage;
		}

		private string releaseCSVObjs()
		{
			string errorMessage = string.Empty;

			try
			{
				if (csvReader != null)
					csvReader.Close();
			}
			catch (Exception ex)
			{
				errorMessage += "Error releasing CSV objects: " + ex.Message + "\n\n";
			}

			csvReader = null;

			return errorMessage;
		}

		/*private string[][] parseCSV(IEnumerable<string> txt, char separator, char encloser, string connector)
		{
			List<string[]> lines = new List<string[]>();
			string[] array = null;

			foreach (string str in txt)
			{
				string[] temp = null;
				if (parseCSV(((array == null) ? "" : encloser.ToString()) + str, separator, encloser, out temp))
				{
					lines.Add((array == null) ? temp : concatStrArrays(array, temp, connector));
					array = null;
				}
				else
				{
					array = (array == null) ? temp : concatStrArrays(array, temp, connector);
				}
			}

			if (array != null)
				lines.Add(array);

			string[][] final = new string[lines.Count][];
			lines.CopyTo(final);
			return final;
		}*/

		/// <returns>false if the last element started with an encloser, but did not end with one.</returns>
		private bool parseCSV(string txt, char separator, char encloser, out string[] result)
		{
			bool complete = true;
			result = null;
			int pos = 0;

			string enclSep = encloser.ToString() + separator.ToString();

			List<string> buf = new List<string>();
			while (pos < txt.Length)
			{
				complete = true;

				if (txt[pos] == encloser)
				{
					int index = pos - 1;
					do
					{
						if (index + 2 >= txt.Length)
							index = -1;
						else
							index = txt.IndexOf(encloser, index + 2);
					} while (index != -1 && txt.Length > index + 1 && txt[index + 1] != separator);

					if (index == -1)
					{
						complete = false;

						buf.Add(txt.Substring(pos + 1, txt.Length - pos - 1));
						pos = txt.Length;
					}
					else if (index + 1 == txt.Length)
					{
						complete = true;

						buf.Add(txt.Substring(pos + 1, txt.Length - pos - 2));
						pos = txt.Length;
					}
					else
					{
						buf.Add(txt.Substring(pos + 1, index - pos - 1));
						pos = index + 2;

						if (pos == txt.Length)
							buf.Add(string.Empty);
					}
				}
				else
				{
					int index = txt.IndexOf(separator, pos);
					if (index == -1)
					{
						buf.Add(txt.Substring(pos, txt.Length - pos));
						pos = txt.Length;
					}
					else
					{
						buf.Add(txt.Substring(pos, index - pos));
						pos = index + 1;

						if (pos == txt.Length)
							buf.Add(string.Empty);
					}
				}
			}

			result = new string[buf.Count];
			buf.CopyTo(result);

			return complete;
		}

		/*private string[] parseCSVNextLine(TextReader reader, char separator, char encloser, string connector)
		{
			bool complete = false;
			string[] fields = null;
			string line = reader.ReadLine();

			while (!complete && line != null)
			{
				string[] temp;

				//line = rmvSpecs(line); // TODO: temporary!

				if (!(complete = parseCSV(line, separator, encloser, out temp)))
					line = encloser.ToString() + reader.ReadLine(); // start with an encloser so that the parser isn't confused

				fields = (fields != null) ? concatStrArrays(fields, temp, connector) : temp;
			}

			int lastField = (fields != null) ? fields.Length - 1 : -1;

			if (!complete && lastField != -1 && fields[lastField].Length > 0)
				fields[lastField] = fields[lastField].Substring(1);

			return fields;
		}*/

		private string[] concatStrArrays(string[] str1, string[] str2, string connector)
		{
			string[] result = new string[str1.Length + str2.Length - 1];

			str1.CopyTo(result, 0);
			str2.CopyTo(result, str1.Length - 1);

			result[str1.Length - 1] = str1[str1.Length - 1] + connector + str2[0];

			return result;
		}

		#endregion CSV Methods
	}
}
