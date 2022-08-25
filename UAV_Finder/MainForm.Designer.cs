partial class MainForm
{
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.TB_MinProb = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.TB_Count = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TB_S = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CB_HumanV = new System.Windows.Forms.ComboBox();
            this.CB_HumanR = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TB_UAVCount = new System.Windows.Forms.TextBox();
            this.CB_UAVTime = new System.Windows.Forms.ComboBox();
            this.CB_UAVr = new System.Windows.Forms.ComboBox();
            this.CB_UAVv = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.BT_Excel = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TB_Met3Prob = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.TB_Met3Time = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TB_Met2Prob = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TB_Met2Time = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TB_Met1Prob = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TB_Met1Time = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BT_Calculate = new System.Windows.Forms.Button();
            this.PBTerritory = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBTerritory)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, -5);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(590, 574);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 568);
            this.panel1.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.TB_MinProb);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.TB_Count);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.TB_S);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Location = new System.Drawing.Point(7, 52);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Size = new System.Drawing.Size(273, 163);
            this.groupBox7.TabIndex = 28;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Общие";
            // 
            // TB_MinProb
            // 
            this.TB_MinProb.Location = new System.Drawing.Point(164, 114);
            this.TB_MinProb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_MinProb.MaxLength = 4;
            this.TB_MinProb.Name = "TB_MinProb";
            this.TB_MinProb.Size = new System.Drawing.Size(100, 22);
            this.TB_MinProb.TabIndex = 32;
            this.TB_MinProb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(8, 118);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(126, 17);
            this.label17.TabIndex = 33;
            this.label17.Text = "Мин. вероятность";
            // 
            // TB_Count
            // 
            this.TB_Count.Location = new System.Drawing.Point(164, 74);
            this.TB_Count.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_Count.MaxLength = 4;
            this.TB_Count.Name = "TB_Count";
            this.TB_Count.Size = new System.Drawing.Size(100, 22);
            this.TB_Count.TabIndex = 2;
            this.TB_Count.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(8, 78);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(129, 17);
            this.label16.TabIndex = 31;
            this.label16.Text = "Кол-во испытаний";
            // 
            // TB_S
            // 
            this.TB_S.Location = new System.Drawing.Point(164, 34);
            this.TB_S.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_S.MaxLength = 5;
            this.TB_S.Name = "TB_S";
            this.TB_S.Size = new System.Drawing.Size(100, 22);
            this.TB_S.TabIndex = 1;
            this.TB_S.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "Площадь, км²";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CB_HumanV);
            this.groupBox2.Controls.Add(this.CB_HumanR);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(6, 219);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(274, 122);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Цель";
            // 
            // CB_HumanV
            // 
            this.CB_HumanV.FormattingEnabled = true;
            this.CB_HumanV.Location = new System.Drawing.Point(165, 34);
            this.CB_HumanV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_HumanV.Name = "CB_HumanV";
            this.CB_HumanV.Size = new System.Drawing.Size(100, 24);
            this.CB_HumanV.TabIndex = 21;
            this.CB_HumanV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KeyPress);
            // 
            // CB_HumanR
            // 
            this.CB_HumanR.FormattingEnabled = true;
            this.CB_HumanR.Location = new System.Drawing.Point(165, 74);
            this.CB_HumanR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_HumanR.Name = "CB_HumanR";
            this.CB_HumanR.Size = new System.Drawing.Size(100, 24);
            this.CB_HumanR.TabIndex = 4;
            this.CB_HumanR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Скорость, км/ч";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Размер сетки, км";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TB_UAVCount);
            this.groupBox1.Controls.Add(this.CB_UAVTime);
            this.groupBox1.Controls.Add(this.CB_UAVr);
            this.groupBox1.Controls.Add(this.CB_UAVv);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(6, 345);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(274, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "БПЛА";
            // 
            // TB_UAVCount
            // 
            this.TB_UAVCount.Location = new System.Drawing.Point(165, 167);
            this.TB_UAVCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_UAVCount.MaxLength = 4;
            this.TB_UAVCount.Name = "TB_UAVCount";
            this.TB_UAVCount.Size = new System.Drawing.Size(100, 22);
            this.TB_UAVCount.TabIndex = 32;
            this.TB_UAVCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KeyPress);
            // 
            // CB_UAVTime
            // 
            this.CB_UAVTime.FormattingEnabled = true;
            this.CB_UAVTime.Location = new System.Drawing.Point(165, 125);
            this.CB_UAVTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_UAVTime.Name = "CB_UAVTime";
            this.CB_UAVTime.Size = new System.Drawing.Size(100, 24);
            this.CB_UAVTime.TabIndex = 24;
            this.CB_UAVTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KeyPress);
            // 
            // CB_UAVr
            // 
            this.CB_UAVr.FormattingEnabled = true;
            this.CB_UAVr.Location = new System.Drawing.Point(165, 79);
            this.CB_UAVr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_UAVr.Name = "CB_UAVr";
            this.CB_UAVr.Size = new System.Drawing.Size(100, 24);
            this.CB_UAVr.TabIndex = 23;
            this.CB_UAVr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KeyPress);
            // 
            // CB_UAVv
            // 
            this.CB_UAVv.FormattingEnabled = true;
            this.CB_UAVv.Location = new System.Drawing.Point(165, 36);
            this.CB_UAVv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_UAVv.Name = "CB_UAVv";
            this.CB_UAVv.Size = new System.Drawing.Size(100, 24);
            this.CB_UAVv.TabIndex = 22;
            this.CB_UAVv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Скорость, км/ч";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Количество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Время работы, ч";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "R видимости, км";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(59, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 25);
            this.label6.TabIndex = 25;
            this.label6.Text = "Исходные данные";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox6);
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(298, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 568);
            this.panel2.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.BT_Excel);
            this.groupBox6.Location = new System.Drawing.Point(7, 435);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(273, 126);
            this.groupBox6.TabIndex = 29;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Эффективность методов";
            // 
            // BT_Excel
            // 
            this.BT_Excel.Enabled = false;
            this.BT_Excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BT_Excel.Location = new System.Drawing.Point(27, 38);
            this.BT_Excel.Name = "BT_Excel";
            this.BT_Excel.Size = new System.Drawing.Size(221, 66);
            this.BT_Excel.TabIndex = 0;
            this.BT_Excel.Text = "Открыть Excel-таблицу";
            this.BT_Excel.UseVisualStyleBackColor = true;
            this.BT_Excel.Click += new System.EventHandler(this.BT_Excel_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TB_Met3Prob);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.TB_Met3Time);
            this.groupBox5.Location = new System.Drawing.Point(7, 308);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(273, 121);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Метод кратчайшего маршрута";
            // 
            // TB_Met3Prob
            // 
            this.TB_Met3Prob.Location = new System.Drawing.Point(164, 74);
            this.TB_Met3Prob.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_Met3Prob.MaxLength = 3;
            this.TB_Met3Prob.Name = "TB_Met3Prob";
            this.TB_Met3Prob.ReadOnly = true;
            this.TB_Met3Prob.Size = new System.Drawing.Size(100, 22);
            this.TB_Met3Prob.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 17);
            this.label14.TabIndex = 18;
            this.label14.Text = "Среднее время, ч";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 78);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 17);
            this.label15.TabIndex = 20;
            this.label15.Text = "Вероятность";
            // 
            // TB_Met3Time
            // 
            this.TB_Met3Time.Location = new System.Drawing.Point(164, 34);
            this.TB_Met3Time.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_Met3Time.MaxLength = 3;
            this.TB_Met3Time.Name = "TB_Met3Time";
            this.TB_Met3Time.ReadOnly = true;
            this.TB_Met3Time.Size = new System.Drawing.Size(100, 22);
            this.TB_Met3Time.TabIndex = 19;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TB_Met2Prob);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.TB_Met2Time);
            this.groupBox4.Location = new System.Drawing.Point(7, 180);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(273, 121);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Метод случайного поиска";
            // 
            // TB_Met2Prob
            // 
            this.TB_Met2Prob.Location = new System.Drawing.Point(164, 74);
            this.TB_Met2Prob.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_Met2Prob.MaxLength = 3;
            this.TB_Met2Prob.Name = "TB_Met2Prob";
            this.TB_Met2Prob.ReadOnly = true;
            this.TB_Met2Prob.Size = new System.Drawing.Size(100, 22);
            this.TB_Met2Prob.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 17);
            this.label12.TabIndex = 18;
            this.label12.Text = "Среднее время, ч";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 17);
            this.label13.TabIndex = 20;
            this.label13.Text = "Вероятность";
            // 
            // TB_Met2Time
            // 
            this.TB_Met2Time.Location = new System.Drawing.Point(164, 34);
            this.TB_Met2Time.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_Met2Time.MaxLength = 3;
            this.TB_Met2Time.Name = "TB_Met2Time";
            this.TB_Met2Time.ReadOnly = true;
            this.TB_Met2Time.Size = new System.Drawing.Size(100, 22);
            this.TB_Met2Time.TabIndex = 19;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TB_Met1Prob);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.TB_Met1Time);
            this.groupBox3.Location = new System.Drawing.Point(7, 52);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(273, 121);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Метод параллельных курсов";
            // 
            // TB_Met1Prob
            // 
            this.TB_Met1Prob.Location = new System.Drawing.Point(164, 74);
            this.TB_Met1Prob.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_Met1Prob.MaxLength = 3;
            this.TB_Met1Prob.Name = "TB_Met1Prob";
            this.TB_Met1Prob.ReadOnly = true;
            this.TB_Met1Prob.Size = new System.Drawing.Size(100, 22);
            this.TB_Met1Prob.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Среднее время, ч";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 17);
            this.label11.TabIndex = 20;
            this.label11.Text = "Вероятность";
            // 
            // TB_Met1Time
            // 
            this.TB_Met1Time.Location = new System.Drawing.Point(164, 34);
            this.TB_Met1Time.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_Met1Time.MaxLength = 3;
            this.TB_Met1Time.Name = "TB_Met1Time";
            this.TB_Met1Time.ReadOnly = true;
            this.TB_Met1Time.Size = new System.Drawing.Size(100, 22);
            this.TB_Met1Time.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(74, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 25);
            this.label7.TabIndex = 26;
            this.label7.Text = "Результаты";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.BT_Calculate);
            this.panel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel4.Location = new System.Drawing.Point(1, 573);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(589, 121);
            this.panel4.TabIndex = 14;
            // 
            // BT_Calculate
            // 
            this.BT_Calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BT_Calculate.Location = new System.Drawing.Point(192, 30);
            this.BT_Calculate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BT_Calculate.Name = "BT_Calculate";
            this.BT_Calculate.Size = new System.Drawing.Size(213, 61);
            this.BT_Calculate.TabIndex = 9;
            this.BT_Calculate.Text = "Рассчитать";
            this.BT_Calculate.UseVisualStyleBackColor = true;
            this.BT_Calculate.Click += new System.EventHandler(this.BT_Calculate_Click);
            // 
            // PBTerritory
            // 
            this.PBTerritory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBTerritory.Location = new System.Drawing.Point(595, 0);
            this.PBTerritory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PBTerritory.Name = "PBTerritory";
            this.PBTerritory.Size = new System.Drawing.Size(695, 695);
            this.PBTerritory.TabIndex = 15;
            this.PBTerritory.TabStop = false;
            this.PBTerritory.Paint += new System.Windows.Forms.PaintEventHandler(this.PBTerritory_Paint);
            // 
            // timer1
            // 
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1291, 695);
            this.Controls.Add(this.PBTerritory);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Оценка эффективности поиска с применением БПЛА";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBTerritory)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.PictureBox PBTerritory;
    private System.Windows.Forms.Button BT_Calculate;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.ComboBox CB_HumanR;
    private System.Windows.Forms.GroupBox groupBox5;
    private System.Windows.Forms.TextBox TB_Met3Prob;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.TextBox TB_Met3Time;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.TextBox TB_Met2Prob;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.TextBox TB_Met2Time;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.TextBox TB_Met1Prob;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox TB_Met1Time;
    private System.Windows.Forms.GroupBox groupBox7;
    private System.Windows.Forms.TextBox TB_Count;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.TextBox TB_S;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox6;
    private System.Windows.Forms.ComboBox CB_HumanV;
    private System.Windows.Forms.ComboBox CB_UAVr;
    private System.Windows.Forms.ComboBox CB_UAVv;
    private System.Windows.Forms.ComboBox CB_UAVTime;
    private System.Windows.Forms.TextBox TB_UAVCount;
    private System.Windows.Forms.TextBox TB_MinProb;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Button BT_Excel;
}