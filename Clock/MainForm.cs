using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection;


namespace Clock
{
	public partial class MainForm : Form
	{
		private PrivateFontCollection fontCollection = new PrivateFontCollection();
		//Font currentFont, customFont;
		private FontFamily defaultFontFamily; // для хранения шрифта по умолчанию при загрузке
		public MainForm()
		{
			InitializeComponent();
			labelTime.BackColor = Color.AliceBlue;
			
			this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, 50);
			ToolStripMenuItemShowControls.Checked = true;

			//currentFont = this.Font;
		}
		void SetVisibility(bool visible)
		{

			cbShowDate.Visible = visible;
			checkBoxShowWeekDay.Visible = visible;
			buttonHideControls.Visible = visible;
			this.FormBorderStyle = visible? FormBorderStyle.FixedDialog: FormBorderStyle.None;
			this.ShowInTaskbar = visible;
			this.TransparencyKey = visible? Color.Empty : this.BackColor;
		}
		private void MainForm_Load(object sender, EventArgs e)
		{

			LoadFontsFromResources(); // загружаем все шрифты
			ApplyFontToControl(this, defaultFontFamily);
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			// Обработчик это самая обычная функция, которая неявно
			// вызывается при возникновеии определенного события, мы написали обработчик события для щелчка таймера
			// у элементов интерфейса может быть множество событий и одно из них будет по умолчанию
			// для таймера событие по умолчанию является тик
			labelTime.Text = DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);  // 12 часовой формат
			//labelTime.Text = DateTime.Now.ToString("HH:mm:ss tt"); // 24 часовой формат
			if(cbShowDate.Checked)
			{
				labelTime.Text += $"\n{DateTime.Now.ToString("yyyy.MM.dd")}";
			}
			if (checkBoxShowWeekDay.Checked)
			{
				labelTime.Text += $"\n{DateTime.Now.DayOfWeek}";
			}
			notifyIcon.Text = 
				$"{DateTime.Now.ToString("hh:mm tt")}\n" +
				$"{DateTime.Now.ToString("yyyy.MM.dd")}\n" +
				$"{DateTime.Now.DayOfWeek}";
		}

		private void buttonHideControls_Click(object sender, EventArgs e)
		{
			showControlsToolStripMenuItemShowControls_CheckedChanged(ToolStripMenuItemShowControls, EventArgs.Empty);
			ToolStripMenuItemShowControls.Checked = false;
			if (!ToolStripMenuItemShowControls.Checked) SetVisibility(false);
			else SetVisibility(true);
		}

		private void labelTime_DoubleClick(object sender, EventArgs e)
		{
			showControlsToolStripMenuItemShowControls_CheckedChanged(ToolStripMenuItemShowControls, EventArgs.Empty);
			ToolStripMenuItemShowControls.Checked = true;
			SetVisibility(true);
		}

		
		private void showControlsToolStripMenuItemShowControls_CheckedChanged(object sender, EventArgs e)
		{
			SetVisibility(ToolStripMenuItemShowControls.Checked);//!buttonHideControls.Visible);
		}


		private void ToolStripMenuItemShowDate_CheckedChanged(object sender, EventArgs e)
		{
			cbShowDate.Checked = !cbShowDate.Checked;
		}

		private void ToolStripMenuItemShowWeekDay_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxShowWeekDay.Checked = !checkBoxShowWeekDay.Checked;
		}

		private void ToolStripMenuItemTopmost_CheckedChanged(object sender, EventArgs e)
		{
			this.TopMost = !this.TopMost;
		}

		// метод обработчик кликов по пунктам меню
		private void ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(sender is ToolStripMenuItem selectedItem)
			{
				LoadFontsFromResources();
				//если пукт уже выбран, снимаем выбор	
				if (!selectedItem.Checked)
				{
					selectedItem.Checked = false;
					//устанавливаем значению по умолчанию
					CheckDefaultMenuItem(selectedItem);

				}
				else
				{
					//сбрасываем состояние всех пуктов подменю
					foreach (ToolStripItem item in selectedItem.Owner.Items)
					{
						if (item is ToolStripMenuItem menuItem)
						{
							menuItem.Checked = false;
						}
					}
					//устанавливаем выбранный пункт и шрифт
					selectedItem.Checked = true;

					if(selectedItem.Text == "Light Led" && fontCollection.Families.Length >0)
					{
						ApplyFontToControl(labelTime, fontCollection.Families[0]);
					}
					else if (selectedItem.Text== "Moscow 2024" && fontCollection.Families.Length >1)
					{
						ApplyFontToControl(labelTime, fontCollection.Families[1]);
					}
					else if (selectedItem.Text == "Terminator" && fontCollection.Families.Length > 2)
					{
						ApplyFontToControl(labelTime, fontCollection.Families[2]);
					}
				}
			}
		}
		//метод для проверки и выбора значения по умолчанию
		private void CheckDefaultMenuItem(ToolStripMenuItem defaultItem)
		{
			bool anyChecked = false;
			// проверяем, выбран ли какой-либо пункт меню
			foreach (ToolStripItem item in defaultItem.Owner.Items)  // цикл по всем элементам в коллекции Items родительского элемента меню (Owner.Items), которая представляет собой коллекцию всех пунктов меню.
			// defaultItem.Owner - это контейнер, которому принадлежит defaultItem, и в котором находятся все элементы меню
			{
				if (item is ToolStripMenuItem menuItem && menuItem.Checked) // чтобы проверить свойство Checked, сначала проверяем на тип, у которого имеется это свойство (не все  элементы коллекции обладают этим свойством, поэтому нужна первая проверка)
				{
					anyChecked = true;
					break;
				}
			}
			// если ничего не выбрано, устанвливаем пункт по умолчанию
			if (!anyChecked)
			{
				ApplyFontToControl(this, defaultFontFamily); //defaultItem.Checked = true;
			}
		}

		//private void ToolStripMenuItemChooseFont_Click(object sender, EventArgs e)
		//{
		//	ToolStripMenuItem it = (ToolStripMenuItem) sender;
		//	//labelTime.Font = it.Checked == true ? customFont : currentFont;
		//	//ApplyFontToControl(labelTime, AddFontToCollection(Properties.Resources.terminat));
		//}
		private void LoadFontsFromResources()
		{
			try
			{
				AddFontToCollectionByAllocMem(Properties.Resources.Light);
				AddFontToCollectionByAllocMem(Properties.Resources.MOSCOW2024);
				AddFontToCollectionByAllocMem(Properties.Resources.Terminator);
				defaultFontFamily = this.Font.FontFamily;
				//AddFontToCollectionByAllocMem(Properties.Resources.DefaultFont);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка загрузки шрифта: {ex.Message}");
			}
		}

		//метод для загрузки шрифта из ресурсов с использованием выделения памяти
		private FontFamily AddFontToCollectionByAllocMem(byte[] fontData)
		{
			// выделяем память для данных шрифта
			IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
			// массив байтов шрифта копируем в выделенную память
			System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
			// загружаем шрифт из памяти в коллекцию шрифтов
			fontCollection.AddMemoryFont(fontPtr, fontData.Length);
			// освобождаем память
			System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
			if (fontCollection.Families.Length == 0)
			{
				throw new Exception("Fonts didn't load");
			}
			return fontCollection.Families[fontCollection.Families.Length-1];  // возвращаем последний в коллекции шрифт
		}

		private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// метод для загрузки шрифта из ресурсов с использованием временного файла
		//private FontFamily AddFontToCollectionByTempFile(byte[] fontData)
		//{
		//	// создаем временный файл
		//	string tempFilePath = Path.GetTempFileName();
		//	//string tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".ttf");

		//	try
		//	{
		//		if(File.Exists(tempFilePath))
		//		{
		//			File.SetAttributes(tempFilePath, FileAttributes.Normal);
		//		}
		//		//FontCollection fontCollection = new FontCollection();
		//		// записываем даннные шрифта во временный файл
		//		File.WriteAllBytes(tempFilePath, fontData);
		//		// добавляем файл шрифта в коллекцию
		//		fontCollection.AddFontFile(tempFilePath);
		//		// проверяем, что файл успешно добавлен
		//		if (fontCollection.Families.Length == 0)
		//		{
		//			throw new Exception("Font could not be loaded");
		//		}
		//		return fontCollection.Families[0];
		//	}
		//	finally
		//	{
		//		// удаляем временный файл
		//		File.Delete(tempFilePath);
		//	}
		//}
		private void ApplyFontToControl(Control control, FontFamily fontFamily)
		{
			control.Font = new Font(fontFamily, control.Font.Size, control.Font.Style);

			// рекурсивное применение к дочерним элементам
			foreach (Control child in control.Controls)
			{
				ApplyFontToControl(child, fontFamily);
			}
		}

		private void ToolStripMenuItemBackgroundColor_Click(object sender, EventArgs e)
		{
			this.BackColor = labelTime.BackColor = buttonHideControls.BackColor = toolStripMenuItemBackgroundColor.Checked ? Color.DarkGreen : DefaultBackColor;
		}

		private void ToolStripMenuItemForegroundColor_Click(object sender, EventArgs e)
		{
			this.ForeColor = toolStripMenuItemForegroundColor.Checked ? Color.Silver : DefaultForeColor;
		}
	}
	public class DoubleBufferedControl : Label
	{
		public DoubleBufferedControl()
		{
			EnableDoubleBuffering();
		}
		public void EnableDoubleBuffering()
		{
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
						ControlStyles.UserPaint |
						ControlStyles.AllPaintingInWmPaint, true);
			this.UpdateStyles();
		}
	}
}
