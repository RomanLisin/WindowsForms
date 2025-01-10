using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Clock
{
	public partial class MainForm : Form
	{
		private PrivateFontCollection fontCollection = new PrivateFontCollection();
		Font currentFont, customFont;
		private FontFamily defaultFontFamily; // для хранения шрифта по умолчанию при загрузке
		public MainForm()
		{
			InitializeComponent();
			labelTime.BackColor = Color.AliceBlue;
			this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, 50);
			
			currentFont = this.Font;
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
			showControlsToolStripMenuItemShowControls.Checked = true;

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
			showControlsToolStripMenuItemShowControls_CheckedChanged(showControlsToolStripMenuItemShowControls, EventArgs.Empty);
			showControlsToolStripMenuItemShowControls.Checked = false;
			if (!showControlsToolStripMenuItemShowControls.Checked) SetVisibility(false);
			else SetVisibility(true);
		}

		private void labelTime_DoubleClick(object sender, EventArgs e)
		{
			showControlsToolStripMenuItemShowControls_CheckedChanged(showControlsToolStripMenuItemShowControls, EventArgs.Empty);
			showControlsToolStripMenuItemShowControls.Checked = true;
			SetVisibility(true);
		}

		
		private void showControlsToolStripMenuItemShowControls_CheckedChanged(object sender, EventArgs e)
		{
			SetVisibility(showControlsToolStripMenuItemShowControls.Checked);//!buttonHideControls.Visible);
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

		private void labelTime_FontChanged(object sender, EventArgs e)
		{
			labelTime.Font = new System.Drawing.Font(labelTime.Font.FontFamily, 32, FontStyle.Regular);
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
			foreach (ToolStripItem item in defaultItem.Owner.Items)
			{
				if (item is ToolStripMenuItem menuItem && menuItem.Checked)
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
				defaultFontFamily = this.Font.FontFamily;//AddFontToCollection(Properties.Resources.DefaultFont);
				Console.WriteLine("Загружен  шрифт по умолчанию");
				AddFontToCollection(Properties.Resources.Light_LED_Display_7);
				Console.WriteLine("Загружен  шрифт digital_7");
				AddFontToCollection(Properties.Resources.MOSCOW2024);
				Console.WriteLine("Загружен  шрифт MOSCOW2024");
				AddFontToCollection(Properties.Resources.terminat);
				Console.WriteLine("Загружен  шрифт terminat");
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка загрузки шрифта: {ex.Message}");
			}
		}

		//метод для загрузки шрифта из ресурсов
		private FontFamily AddFontToCollection(byte[] fontData)
		{
			IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
			System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
			fontCollection.AddMemoryFont(fontPtr, fontData.Length);
			System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
			if (fontCollection.Families.Length == 0)
			{
				throw new Exception("Fonts didn't load");
			}
			return fontCollection.Families[fontCollection.Families.Length-1];
		}
		private void ApplyFontToControl(Control control, FontFamily fontFamily)
		{
			control.Font = new Font(fontFamily, control.Font.Size, control.Font.Style);

			// рекурсивное применение к дочерним элементам
			foreach (Control child in control.Controls)
			{
				ApplyFontToControl(child, fontFamily);
			}
		}
	}
}
