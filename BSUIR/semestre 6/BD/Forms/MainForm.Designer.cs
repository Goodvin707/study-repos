namespace TravelAgency_DB_GUI.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Дополнительные услуги");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Услуги бронирования", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Бронирования", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Отели");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Города", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Сезоны");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Страны", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Транспорты");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Типы туров");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Туроператоры");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Туры", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Должности сотрудников");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Комиссии сотрудников");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Сотрудники", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Документы клиентов");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Клиенты", new System.Windows.Forms.TreeNode[] {
            treeNode15});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loggerTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearHistoryWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.searchStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.searchStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.searchToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSQLQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recoveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createBackupStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recoveryStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mySQLUtilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mysqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mysqlbinlogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mysqldumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mysqlpumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.wordStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(531, 401);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.tabControl1_ControlAdded);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator4,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator3,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(177, 126);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.addToolStripMenuItem.Text = "Добавить";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.editToolStripMenuItem.Text = "Изменить";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(173, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.refreshToolStripMenuItem.Text = "Обновить таблицу";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(173, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.closeToolStripMenuItem.Text = "Закрыть";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 426);
            this.splitContainer1.SplitterDistance = 265;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(265, 426);
            this.splitContainer2.SplitterDistance = 218;
            this.splitContainer2.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Window;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "additional_services";
            treeNode1.Text = "Дополнительные услуги";
            treeNode2.Name = "booking_services";
            treeNode2.Text = "Услуги бронирования";
            treeNode3.Name = "bookings";
            treeNode3.Text = "Бронирования";
            treeNode4.Name = "hotels";
            treeNode4.Text = "Отели";
            treeNode5.Name = "cities";
            treeNode5.Text = "Города";
            treeNode6.Name = "seasons";
            treeNode6.Text = "Сезоны";
            treeNode7.Name = "countries";
            treeNode7.Text = "Страны";
            treeNode8.Name = "transports";
            treeNode8.Text = "Транспорты";
            treeNode9.Name = "tour_types";
            treeNode9.Text = "Типы туров";
            treeNode10.Name = "tour_operators";
            treeNode10.Text = "Туроператоры";
            treeNode11.Name = "tours";
            treeNode11.Text = "Туры";
            treeNode12.Name = "employee_positions";
            treeNode12.Text = "Должности сотрудников";
            treeNode13.Name = "employee_commissions";
            treeNode13.Text = "Комиссии сотрудников";
            treeNode14.Name = "employees";
            treeNode14.Text = "Сотрудники";
            treeNode15.Name = "client_documents";
            treeNode15.Text = "Документы клиентов";
            treeNode16.Name = "clients";
            treeNode16.Text = "Клиенты";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode7,
            treeNode11,
            treeNode14,
            treeNode16});
            this.treeView1.Size = new System.Drawing.Size(265, 218);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.loggerTextBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 204);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "История";
            // 
            // loggerTextBox
            // 
            this.loggerTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.loggerTextBox.ContextMenuStrip = this.contextMenuStrip2;
            this.loggerTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loggerTextBox.Location = new System.Drawing.Point(3, 16);
            this.loggerTextBox.Multiline = true;
            this.loggerTextBox.Name = "loggerTextBox";
            this.loggerTextBox.ReadOnly = true;
            this.loggerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.loggerTextBox.Size = new System.Drawing.Size(259, 185);
            this.loggerTextBox.TabIndex = 0;
            this.loggerTextBox.WordWrap = false;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearHistoryWindowToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(206, 26);
            // 
            // clearHistoryWindowToolStripMenuItem
            // 
            this.clearHistoryWindowToolStripMenuItem.Name = "clearHistoryWindowToolStripMenuItem";
            this.clearHistoryWindowToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.clearHistoryWindowToolStripMenuItem.Text = "Очистить окно истории";
            this.clearHistoryWindowToolStripMenuItem.Click += new System.EventHandler(this.clearHistoryWindowToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 401);
            this.panel1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.searchStripComboBox,
            this.searchStripTextBox,
            this.searchToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(531, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel1.Text = "Поиск";
            // 
            // searchStripComboBox
            // 
            this.searchStripComboBox.BackColor = System.Drawing.Color.White;
            this.searchStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchStripComboBox.Name = "searchStripComboBox";
            this.searchStripComboBox.Size = new System.Drawing.Size(121, 25);
            // 
            // searchStripTextBox
            // 
            this.searchStripTextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.searchStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.searchStripTextBox.Name = "searchStripTextBox";
            this.searchStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // searchToolStripButton
            // 
            this.searchToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchToolStripButton.Image = global::TravelAgency_DB_GUI.Properties.Resources.search;
            this.searchToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchToolStripButton.Name = "searchToolStripButton";
            this.searchToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.searchToolStripButton.Text = "Поиск";
            this.searchToolStripButton.Click += new System.EventHandler(this.searchToolStripButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.mySQLUtilsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSQLQueryToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.toolStripSeparator1,
            this.logsToolStripMenuItem,
            this.recoveryToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.adminToolStripMenuItem.Text = "Администрирование";
            // 
            // newSQLQueryToolStripMenuItem
            // 
            this.newSQLQueryToolStripMenuItem.Name = "newSQLQueryToolStripMenuItem";
            this.newSQLQueryToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.newSQLQueryToolStripMenuItem.Text = "Новый SQL-запрос";
            this.newSQLQueryToolStripMenuItem.Click += new System.EventHandler(this.newSQLQueryToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.usersToolStripMenuItem.Text = "Пользователи";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            this.logsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.logsToolStripMenuItem.Text = "Просмотр логов";
            this.logsToolStripMenuItem.Click += new System.EventHandler(this.logsToolStripMenuItem_Click);
            // 
            // recoveryToolStripMenuItem
            // 
            this.recoveryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createBackupStripMenuItem,
            this.recoveryStripMenuItem});
            this.recoveryToolStripMenuItem.Name = "recoveryToolStripMenuItem";
            this.recoveryToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.recoveryToolStripMenuItem.Text = "Восстановление";
            // 
            // createBackupStripMenuItem
            // 
            this.createBackupStripMenuItem.Name = "createBackupStripMenuItem";
            this.createBackupStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.createBackupStripMenuItem.Text = "Создать копию базы данных";
            this.createBackupStripMenuItem.Click += new System.EventHandler(this.createBackupStripMenuItem_Click);
            // 
            // recoveryStripMenuItem
            // 
            this.recoveryStripMenuItem.Name = "recoveryStripMenuItem";
            this.recoveryStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.recoveryStripMenuItem.Text = "Восстановить";
            this.recoveryStripMenuItem.Click += new System.EventHandler(this.recoveryStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(176, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.exitToolStripMenuItem.Text = "Вы&ход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mySQLUtilsToolStripMenuItem
            // 
            this.mySQLUtilsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mysqlToolStripMenuItem,
            this.mysqlbinlogToolStripMenuItem,
            this.mysqldumpToolStripMenuItem,
            this.mysqlpumpToolStripMenuItem});
            this.mySQLUtilsToolStripMenuItem.Name = "mySQLUtilsToolStripMenuItem";
            this.mySQLUtilsToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.mySQLUtilsToolStripMenuItem.Text = "MySQL Утилиты";
            // 
            // mysqlToolStripMenuItem
            // 
            this.mysqlToolStripMenuItem.Name = "mysqlToolStripMenuItem";
            this.mysqlToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mysqlToolStripMenuItem.Text = "mysql";
            this.mysqlToolStripMenuItem.Click += new System.EventHandler(this.mysqlToolStripMenuItem_Click);
            // 
            // mysqlbinlogToolStripMenuItem
            // 
            this.mysqlbinlogToolStripMenuItem.Name = "mysqlbinlogToolStripMenuItem";
            this.mysqlbinlogToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mysqlbinlogToolStripMenuItem.Text = "mysqlbinlog";
            this.mysqlbinlogToolStripMenuItem.Click += new System.EventHandler(this.mysqlbinlogToolStripMenuItem_Click);
            // 
            // mysqldumpToolStripMenuItem
            // 
            this.mysqldumpToolStripMenuItem.Name = "mysqldumpToolStripMenuItem";
            this.mysqldumpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mysqldumpToolStripMenuItem.Text = "mysqldump";
            this.mysqldumpToolStripMenuItem.Click += new System.EventHandler(this.mysqldumpToolStripMenuItem_Click);
            // 
            // mysqlpumpToolStripMenuItem
            // 
            this.mysqlpumpToolStripMenuItem.Name = "mysqlpumpToolStripMenuItem";
            this.mysqlpumpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mysqlpumpToolStripMenuItem.Text = "mysqlpump";
            this.mysqlpumpToolStripMenuItem.Click += new System.EventHandler(this.mysqlpumpStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordStripMenuItem,
            this.excelStripMenuItem,
            this.printStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(64, 20);
            this.toolStripMenuItem1.Text = "Экспорт";
            // 
            // wordStripMenuItem
            // 
            this.wordStripMenuItem.Name = "wordStripMenuItem";
            this.wordStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.wordStripMenuItem.Text = "Word (.docx)";
            this.wordStripMenuItem.Click += new System.EventHandler(this.wordToolStripMenuItem_Click);
            // 
            // excelStripMenuItem
            // 
            this.excelStripMenuItem.Name = "excelStripMenuItem";
            this.excelStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.excelStripMenuItem.Text = "Excel (.xlsx)";
            this.excelStripMenuItem.Click += new System.EventHandler(this.excelStripMenuItem_Click);
            // 
            // printStripMenuItem
            // 
            this.printStripMenuItem.Name = "printStripMenuItem";
            this.printStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.printStripMenuItem.Text = "Печать (.pdf)";
            this.printStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "База данных турагенства";
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSQLQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mySQLUtilsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mysqlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mysqlbinlogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mysqldumpToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem clearHistoryWindowToolStripMenuItem;
        private System.Windows.Forms.TextBox loggerTextBox;
        private System.Windows.Forms.ToolStripMenuItem recoveryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox searchStripComboBox;
        private System.Windows.Forms.ToolStripTextBox searchStripTextBox;
        private System.Windows.Forms.ToolStripButton searchToolStripButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem wordStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createBackupStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recoveryStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mysqlpumpToolStripMenuItem;
    }
}