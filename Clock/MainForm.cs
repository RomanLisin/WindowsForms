using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

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
		}

		private void buttonHideControls_Click(object sender, EventArgs e)
		{

		}
	}
}
