using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Clock
{
	public partial class MainForm : Form
	{
		private PrivateFontCollection _fonts = new PrivateFontCollection();
		Font currentFont, customFont;
		public MainForm()
		{
			InitializeComponent();
			labelTime.BackColor = Color.AliceBlue;
			this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, 50);
			
			currentFont = this.Font;
			SetSelectedValue("first value");
			//currentFont.Size = labelTime.Font.Size;
			//LoadCustomFont();
			//ApplyFontToLabelTime();
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
		private void LoadCustomFont()
		{
			string fontPath = "C:\\Users\\rls\\source\\repos\\WindowsDevelopment\\WinAPI\\Calc\\Fonts\\light-led-display-7\\light_led_display-7.ttf";
			try
			{
				//загружаем шрифт
				_fonts.AddFontFile(fontPath);
			}
			catch (Exception ex)
			{

				MessageBox.Show($"Loader font error: {ex.Message}");
			}
		}

		private void ApplyFontToLabelTime()
		{
			if(_fonts.Families.Length >0)
			{
				// создаем шрифт с заданным размером
				customFont = new Font(_fonts.Families[0], 32, FontStyle.Regular);
			}
			else
			{
				MessageBox.Show("Font don't loaded");
			}
		}

		private void ToolStripMenuItemTopmost_CheckedChanged(object sender, EventArgs e)
		{
			this.TopMost = !this.TopMost;
		}

		private void labelTime_FontChanged(object sender, EventArgs e)
		{
			labelTime.Font = new System.Drawing.Font(labelTime.Font.FontFamily, 32, FontStyle.Regular);
		}


		private string defaultValue = "Значение по умолчанию";

		// метод обработчик кликов по пунктам меню
		private void ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(sender is ToolStripMenuItem selectedItem)
			{
				//если пукт уже выбран, снимаем выбор	
				if (!selectedItem.Checked)
				{
					selectedItem.Checked = false;
					//устанавливаем значению по умолчанию
					SetDefaultValue();
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
					//устанавливаем выбранный пункт
					selectedItem.Checked = true;
					SetSelectedValue(selectedItem.Text);
				}
			}
		}
		//метод для установки значения по умолчанию
		private void SetDefaultValue()
		{
			// значению по умолчанию
			MessageBox.Show("Default value");
		}

		//метод для установки выбранного значения
		private void SetSelectedValue(string value)
		{
			MessageBox.Show("Selected value");
		}
		//private void ToolStripMenuItem_Click(object sender, EventArgs e)
		//{
		//	if(sender is ToolStripMenuItem selectedItem)
		//	{
		//		//сбрасываем состояние всех пунктов меню
		//		foreach (ToolStripItem item in selectedItem.Owner.Items)
		//		{
		//			if(item is ToolStripMenuItem menuItem)
		//			{
		//				menuItem.Checked = false;
		//			}
		//		}
		//		// устанавливаем Checked для выбранного пункта 
		//		selectedItem.Checked = true;
		//	}
		//}

		//метод для проверки и выбора значения по умолчанию 
		//private void CheckDefaultMenuItem(ToolStripMenuItem defaultItem)
		//{
		//	bool anyChecked = false;
		//	// проверяем, выбран ли какой-либо пункт меню
		//	foreach (ToolStripItem item in defaultItem.Owner.Items)
		//	{
		//		if (item is ToolStripMenuItem menuItem && menuItem.Checked)
		//		{
		//			anyChecked = true;
		//			break;
		//		}
		//	}
		//	// если ничего не выбрано, устанвливаем пункт по умолчанию
		//	if (!anyChecked)
		//	{
		//		defaultItem.Checked = true;
		//	}
		//}

		private void ToolStripMenuItemChooseFont_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem it = (ToolStripMenuItem) sender;
			labelTime.Font = it.Checked == true ? customFont : currentFont;
			
		}
	}
}
