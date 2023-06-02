using RealEstateHomework.DBElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstateHomework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBManager manager = DBManager.Instance;
            Client client = manager.GetClient(4);
            MessageBox.Show(client.name);
        }

        
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void clientToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panel2.Visible = true;
        }

        private void propertyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panel1.Visible = true;
        }

        private void agentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panel3.Visible = true;
        }

        private void contractToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            panel4.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            resultpanel.Visible = true;

            int clientID;
            try
            {
                clientID = Convert.ToInt32(clientField.Text);
            }
            catch {
                MessageBox.Show("Please Enter Valid ID");
                return;
            }
            CleanResultsPanel();
            Client client = DBManager.Instance.GetClient(clientID);


            Label header = new Label();
            header.Text = "Client Results";
            header.Location = new Point(38, 36);
            header.AutoSize = true;

            Label lbl1 = new Label();
            lbl1.Text = "ID:" + client.id.ToString();
            lbl1.Location = new Point(210, 91);
            lbl1.AutoSize = true;

            Label lbl2 = new Label();
            lbl2.Text = "Username:" + client.username;
            lbl2.Location = new Point(210, 121);
            lbl2.AutoSize = true;

            Label lbl3 = new Label();
            lbl3.Text = "Password:" + client.password;
            lbl3.Location = new Point(210, 151);
            lbl3.AutoSize = true;

            Label lbl4 = new Label();
            lbl4.Text = "Name:" + client.name;
            lbl4.Location = new Point(210, 181);
            lbl4.AutoSize = true;

            Label lbl5 = new Label();
            lbl5.Text = "Phone Number:" + client.phoneNumber;
            lbl5.Location = new Point(210, 211);
            lbl5.AutoSize = true;

            Label lbl6 = new Label();
            lbl6.Text = "Prefferred Property Type:" + client.prefferedPropertyType;
            lbl6.Location = new Point(210, 241);
            lbl6.AutoSize = true;

            Label lbl7 = new Label();
            lbl7.Text = "Shown Property IDs:" + client.shownPropertyIDs;
            lbl7.Location = new Point(210, 271);
            lbl7.AutoSize = true;

            Label lbl8 = new Label();
            lbl8.Text = "Created At:" + client.created_at.ToString();
            lbl8.Location = new Point(210, 301);
            lbl8.AutoSize = true;

            // Add the label to the resultPanel
            resultpanel.Controls.Add(lbl1);
            resultpanel.Controls.Add(lbl2);
            resultpanel.Controls.Add(lbl3);
            resultpanel.Controls.Add(lbl4);
            resultpanel.Controls.Add(lbl5);
            resultpanel.Controls.Add(lbl6);
            resultpanel.Controls.Add(lbl7);
            resultpanel.Controls.Add(lbl8);
            resultpanel.Controls.Add(header);

            // Refresh the resultPanel to update the display
            resultpanel.Refresh();
        }

        private void HideAllPanels()
        {
            panel4.Visible = false;
            panel3.Visible = false;
            panel2.Visible = false;
            panel1.Visible = false;
            resultpanel.Visible = false;
            insertpanel.Visible = false;
            bannerpanel.Visible = false;
            viewpanel.Visible = false;
            analyzepanel.Visible = false;
            searchpropertypr.Visible = false;
        }

        private void searchcontractbtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            resultpanel.Visible = true;

            int contractID;
            try
            {
                contractID = Convert.ToInt32(contractField.Text);
            }
            catch
            {
                MessageBox.Show("Please Enter Valid ID");
                return;
            }

            CleanResultsPanel();
            DBElements.Contract contract = DBManager.Instance.GetContract(contractID);

            Label header = new Label();
            header.Text = "Contract Results";
            header.Location = new Point(38, 36);


            AddLabel(resultpanel, "ID:" + contract.id.ToString(), 0);
            AddLabel(resultpanel, "AgentID:" + contract.agentID.ToString(), 1);
            AddLabel(resultpanel, "ClientID: " + contract.clientID.ToString(), 2);
            AddLabel(resultpanel, "PropertyID:" + contract.propertyID.ToString(), 3);
            AddLabel(resultpanel, "Deal Price:" + contract.dealPrice.ToString(), 4);
            AddLabel(resultpanel, "Date:" + contract.date.ToString(), 5);

            resultpanel.Controls.Add(header);
            // Refresh the resultPanel to update the display
            resultpanel.Refresh();
        }

        private void searchagentbtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            resultpanel.Visible = true;

            int agentID;
            try
            {
                agentID = Convert.ToInt32(agentField.Text);
            }
            catch
            {
                MessageBox.Show("Please Enter Valid ID");
                return;
            }

            CleanResultsPanel();
            Agent agent = DBManager.Instance.GetAgent(agentID);

            Label header = new Label();
            header.Text = "Agent Results";
            header.Location = new Point(38, 36);


            AddLabel(resultpanel, "ID:" + agent.id.ToString(), 0);
            AddLabel(resultpanel, "Username:" + agent.username.ToString(), 1);
            AddLabel(resultpanel, "Password: " + agent.password.ToString(), 2);
            AddLabel(resultpanel, "Commission Rate:" + agent.commissionRate.ToString(), 3);
            AddLabel(resultpanel, "Phone Number:" + agent.phoneNumber.ToString(), 4);
            AddLabel(resultpanel, "Address:" + agent.address.ToString(), 5);
            AddLabel(resultpanel, "Total Earned Commission:" + agent.totalEarnedCommission.ToString(), 6);
            AddLabel(resultpanel, "Created At:" + agent.created_at.ToString(), 7);

            resultpanel.Controls.Add(header);
            // Refresh the resultPanel to update the display
            resultpanel.Refresh();
        }

        private void propertybtn_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            resultpanel.Visible = true;

            int propertyID;
            try
            {
                propertyID = Convert.ToInt32(propertyField.Text);
            }
            catch
            {
                MessageBox.Show("Please Enter Valid ID");
                return;
            }

            CleanResultsPanel();
            Property property = DBManager.Instance.GetProperty(propertyID);

            Label header = new Label();
            header.Text = "Property Results";
            header.Location = new Point(38, 36);


            AddLabel(resultpanel, "ID:" + property.id.ToString(), 0);
            AddLabel(resultpanel, "Price:" + property.price.ToString(), 1);
            AddLabel(resultpanel, "Room Number: " + property.roomNumber.ToString(), 2);
            AddLabel(resultpanel, "Type:" + property.type.ToString(), 3);
            AddLabel(resultpanel, "Address:" + property.address.ToString(), 4);
            AddLabel(resultpanel, "Listing Date:" + property.listingDate.ToString(), 5);
            AddLabel(resultpanel, "Feedback Rating:" + property.feedbackRating.ToString(), 6);

            resultpanel.Controls.Add(header);
            // Refresh the resultPanel to update the display
            resultpanel.Refresh();
        }



        void AddLabel(Panel panel, string label, int offset)
        {
            Label lbl = new Label();
            lbl.Text = label;
            lbl.Location = new Point(210, 91 + (30 * offset));
            lbl.AutoSize = true;

            panel.Controls.Add(lbl);
        }
        void CleanResultsPanel()
        {
            foreach (Control control in resultpanel.Controls)
            {
                control.Dispose();
            }
            resultpanel.Controls.Clear();
        }
        void CleanInsertionPanel()
        {
            foreach (Control control in insertpanel.Controls)
            {
                control.Dispose();           
            }
            insertpanel.Controls.Clear();
        }
        void CleanViewPanel()
        {
            foreach (Control control in viewpanel.Controls)
            {
                if(control is DataGridView)
                {
                    (control as DataGridView).DataSource = null;
                }
                control.Dispose();
            }
            viewpanel.Controls.Clear();
        }
        void CleanAnalyzePanel()
        {
            foreach (Control control in analyzepanel.Controls)
            {
                if (control is DataGridView)
                {
                    (control as DataGridView).DataSource = null;
                }
                control.Dispose();
            }
            analyzepanel.Controls.Clear();
        }
        void CleanSearchPropertyPanel()
        {
            foreach (Control control in searchpropertypr.Controls)
            {
                if (control is DataGridView)
                {
                    (control as DataGridView).DataSource = null;
                }
                control.Dispose();
            }
            searchpropertypr.Controls.Clear();
        }

        List<Control> tempinputFields = new List<Control>();
        TextBox CreateInputField(string label, int offset)
        {
            Label lbl = new Label();
            lbl.Text = label;
            lbl.Location = new Point(13, 70 + (offset * 30));
            lbl.AutoSize = true;

            TextBox field = new TextBox();
            field.Location = new Point(200, 70 + (offset * 30));
            field.AutoSize = true;
            field.Width = 200;
            tempinputFields.Add(field);

            insertpanel.Controls.Add(lbl);
            insertpanel.Controls.Add(field);

            return field;
        }
        ComboBox CreateSelectableField(string label, int offset, string[] args)
        {
            Label lbl = new Label();
            lbl.Text = label;
            lbl.Location = new Point(13, 70 + (offset * 30));
            lbl.AutoSize = true;

            ComboBox field = new ComboBox();
            field.Location = new Point(200, 70 + (offset * 30));
            field.AutoSize = true;
            field.Width = 200;

            foreach (string arg in args)
            {
                field.Items.Add(arg);
            }
            tempinputFields.Add(field);

            insertpanel.Controls.Add(lbl);
            insertpanel.Controls.Add(field);

            return field;
        }


        static Tab currentTab;
        static int currentPageIndex = 0;
        enum Tab { Client, Property, Contract, Agent}

        private void applyinsertionbtn_Click(object sender, EventArgs e)
        {
            DBManager manager = DBManager.Instance;
            switch (currentTab)
            {
                case Tab.Client:
                    Client client;
                    try
                    {
                        client = new Client(
                        tempinputFields[0].Text,
                        tempinputFields[1].Text,
                        tempinputFields[2].Text,
                        tempinputFields[3].Text,
                        tempinputFields[4].Text,
                        tempinputFields[5].Text,
                        tempinputFields[6].Text,
                        tempinputFields[7].Text,
                        DateTime.Now
                        );
                    }
                    catch (Exception message)
                    {
                        MessageBox.Show("Please enter valid arguments.\n" +
                            message.Message);
                        return;
                    }
                    manager.InsertClient(client);
                    MessageBox.Show("Client Added Successfully. " + client.name );
                    break;
                case Tab.Property:
                    Property property;
                    try
                    {
                        property = new Property(
                        Convert.ToInt32(tempinputFields[0].Text),
                        Convert.ToInt32(tempinputFields[1].Text),
                        tempinputFields[2].Text,
                        tempinputFields[3].Text,
                        DateTime.Now,
                        Convert.ToSingle(tempinputFields[4].Text)
                        );
                    }
                    catch (Exception message)
                    {
                        MessageBox.Show("Please enter valid arguments.\n" +
                            message.Message);
                        throw;
                        return;
                    }
                    manager.InsertProperty(property);
                    MessageBox.Show("Property Added Successfully. Property Address: " + property.address);
                    break;
                case Tab.Agent:
                    Agent agent;
                    try
                    {
                        agent = new Agent(
                        tempinputFields[0].Text,
                        tempinputFields[1].Text,
                        Convert.ToSingle(tempinputFields[2].Text),
                        Convert.ToInt32(tempinputFields[3].Text),
                        tempinputFields[4].Text,
                        Convert.ToInt32(tempinputFields[5].Text),
                        DateTime.Now
                        );
                    }
                    catch (Exception message)
                    {
                        MessageBox.Show("Please enter valid arguments.\n" +
                            message.Message);
                        return;
                    }
                    manager.InsertAgent(agent);
                    MessageBox.Show("Agent Added Successfully. Agent ID: " + agent.id);
                    break;
                case Tab.Contract:
                    Contract contract;
                    try
                    {
                        contract = new Contract(
                        Convert.ToInt32(tempinputFields[0].Text),
                        Convert.ToInt32(tempinputFields[1].Text),
                        Convert.ToInt32(tempinputFields[2].Text),
                        Convert.ToSingle(tempinputFields[3].Text),
                        DateTime.Now
                        );
                    }
                    catch (Exception message)
                    {
                        MessageBox.Show("Please enter valid arguments.\n" +
                            message.Message);
                        return;
                    }
                    manager.InsertContract(contract);
                    MessageBox.Show("Contract Added Successfully. Contract ID: " + contract.id);
                    break;
            }
            tempinputFields.Clear();
        }

        void CreateInsertionApplyBtn()
        {
            Button button = new Button();
            button.Click += applyinsertionbtn_Click;
            button.Location = new Point(599, 327);
            button.Size = new Size(100, 31);
            button.Text = "Apply";

            insertpanel.Controls.Add(button);
        }

        private void clientToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            currentTab = Tab.Client;
            HideAllPanels();
            CleanInsertionPanel();
            insertpanel.Visible = true;

            CreateInputField("Username", 0);
            CreateInputField("Password", 1);
            CreateInputField("Name", 2);
            CreateInputField("Phone Number", 3);
            CreateSelectableField("Preffered Property Type", 4, new string[] {"For Sale","For Rent"});
            CreateInputField("Preffered Location", 5);
            CreateInputField("Price Range", 6);
            CreateInputField("Shown Property ID", 7);
            CreateInsertionApplyBtn();
            insertpanel.Refresh();
        }
        private void propertyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            currentTab = Tab.Property;
            HideAllPanels();
            CleanInsertionPanel();
            insertpanel.Visible = true;

            CreateInputField("Price", 0);
            CreateInputField("RoomNumber", 1);
            CreateSelectableField("Type", 2, new string[] { "For Sale", "For Rent" });
            CreateInputField("Address", 3);
            CreateInputField("Feedback Rating", 4);
            CreateInsertionApplyBtn();
            insertpanel.Refresh();
        }

        private void contractToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            currentTab = Tab.Contract;
            HideAllPanels();
            CleanInsertionPanel();
            insertpanel.Visible = true;

            CreateInputField("Client ID", 0);
            CreateInputField("Agent ID", 1);
            CreateInputField("Property ID", 2);
            CreateInputField("Deal Price", 3);
            CreateInsertionApplyBtn();
            insertpanel.Refresh();
        }

        private void agentToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            currentTab = Tab.Agent;
            HideAllPanels();
            CleanInsertionPanel();
            insertpanel.Visible = true;

            CreateInputField("Username", 0);
            CreateInputField("Password", 1);
            CreateInputField("Commission Rate", 2);
            CreateInputField("Phone Number", 3);
            CreateInputField("Address", 4);
            CreateInputField("Total Earned Commission", 5);
            CreateInsertionApplyBtn();
            insertpanel.Refresh();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanInsertionPanel();
            CleanResultsPanel();
            HideAllPanels();
            bannerpanel.Visible = true;
            bannerpanel.Refresh();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintClientsDbResults(0);
        }

        void PrintClientsDbResults(int page)
        {
            if (page < 0)
                return;
            currentPageIndex = page;
            currentTab = Tab.Client;
            HideAllPanels();
            viewpanel.Visible = true;
            CleanViewPanel();

            List<Client> clients = DBManager.Instance.GetClients((page * 10), ((page + 1) * 10));

            DataGridView grid = new DataGridView();
            grid.Location = new Point(31, 48);
            grid.Size = new Size(716, 317);
            grid.Columns.Add("id", "id");
            grid.Columns.Add("username", "username");
            grid.Columns.Add("password", "password");
            grid.Columns.Add("name", "name");
            grid.Columns.Add("phoneNumber", "phoneNumber");
            grid.Columns.Add("preffered Property Type", "preffered Property Type");
            grid.Columns.Add("preffered Location", "preffered Location");
            grid.Columns.Add("Price Range", "Price Range");
            grid.Columns.Add("shown Property IDs", "shown Property IDs");
            grid.Columns.Add("created at", "created at");

            Label lbl = new Label();
            lbl.Text = "Viewing Clients";
            lbl.Location = new Point(25, 16);
            lbl.AutoSize = true;


            foreach (Client client in clients)
            {
                grid.Rows.Add(client.id, client.username,client.password, client.name, client.phoneNumber, client.prefferedPropertyType,client.prefferedLocation,client.priceRange, client.shownPropertyIDs, client.created_at);
            }

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Button prevBtn = new Button();
            prevBtn.Click += prevPage_Click_1;
            prevBtn.Location = new Point(273, 435);
            prevBtn.Size = new Size(75, 23);
            prevBtn.Text = "Previous";

            Button nxtBtn = new Button();
            nxtBtn.Click += nxtPage_Click_1;
            nxtBtn.Location = new Point(406, 435);
            nxtBtn.Size = new Size(75, 23);
            nxtBtn.Text = "Next";

            TextBox pageField = new TextBox();
            pageField.Location = new Point(352, 435);
            pageField.Size = new Size(48, 22);
            pageField.Text = page.ToString();

            viewpanel.Controls.Add(grid);
            viewpanel.Controls.Add(prevBtn);
            viewpanel.Controls.Add(nxtBtn);
            viewpanel.Controls.Add(pageField);
            viewpanel.Controls.Add(lbl);
            viewpanel.Refresh();
        }
        void PrintPropertiesDbResults(int page)
        {
            if (page < 0)
                return;
            currentPageIndex = page;
            currentTab = Tab.Property;
            HideAllPanels();
            viewpanel.Visible = true;
            CleanViewPanel();

            List<Property> properties = DBManager.Instance.GetProperties((page * 10), ((page + 1) * 10));

            DataGridView grid = new DataGridView();
            grid.Location = new Point(31, 48);
            grid.Size = new Size(716, 317);
            grid.Columns.Add("id", "id");
            grid.Columns.Add("price", "price");
            grid.Columns.Add("roomNumber", "roomNumber");
            grid.Columns.Add("type", "type");
            grid.Columns.Add("address", "address");
            grid.Columns.Add("listingDate", "listingDate");
            grid.Columns.Add("feedbackRating", "feedbackRating");

            Label lbl = new Label();
            lbl.Text = "Viewing Properties";
            lbl.Location = new Point(25, 16);
            lbl.AutoSize = true;

            foreach (Property property in properties)
            {
                grid.Rows.Add(property.id,property.price,property.roomNumber,property.type,property.address,property.listingDate.ToString(),property.feedbackRating);
            }

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Button prevBtn = new Button();
            prevBtn.Click += prevPage_Click_1;
            prevBtn.Location = new Point(273, 435);
            prevBtn.Size = new Size(75, 23);
            prevBtn.Text = "Previous";

            Button nxtBtn = new Button();
            nxtBtn.Click += nxtPage_Click_1;
            nxtBtn.Location = new Point(406, 435);
            nxtBtn.Size = new Size(75, 23);
            nxtBtn.Text = "Next";

            TextBox pageField = new TextBox();
            pageField.Location = new Point(352, 435);
            pageField.Size = new Size(48, 22);
            pageField.Text = page.ToString();

            viewpanel.Controls.Add(grid);
            viewpanel.Controls.Add(prevBtn);
            viewpanel.Controls.Add(nxtBtn);
            viewpanel.Controls.Add(pageField);
            viewpanel.Controls.Add(lbl);
            viewpanel.Refresh();
        }
        void PrintContractsDbResults(int page)
        {
            if (page < 0)
                return;
            currentPageIndex = page;
            currentTab = Tab.Contract;
            HideAllPanels();
            viewpanel.Visible = true;
            CleanViewPanel();

            List<Contract> contracts = DBManager.Instance.GetContracts((page * 10), ((page + 1) * 10));

            DataGridView grid = new DataGridView();
            grid.Location = new Point(31, 48);
            grid.Size = new Size(716, 317);
            grid.Columns.Add("id", "id");
            grid.Columns.Add("clientID", "clientID");
            grid.Columns.Add("agentID", "agentID");
            grid.Columns.Add("propertyID", "propertyID");
            grid.Columns.Add("dealPrice", "dealPrice");
            grid.Columns.Add("date", "date");

            Label lbl = new Label();
            lbl.Text = "Viewing Contracts";
            lbl.Location = new Point(25, 16);
            lbl.AutoSize = true;

            foreach (Contract contract in contracts)
            {
                grid.Rows.Add(contract.id, contract.clientID,contract.agentID,contract.propertyID, contract.dealPrice, contract.date.ToString());
            }

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Button prevBtn = new Button();
            prevBtn.Click += prevPage_Click_1;
            prevBtn.Location = new Point(273, 435);
            prevBtn.Size = new Size(75, 23);
            prevBtn.Text = "Previous";

            Button nxtBtn = new Button();
            nxtBtn.Click += nxtPage_Click_1;
            nxtBtn.Location = new Point(406, 435);
            nxtBtn.Size = new Size(75, 23);
            nxtBtn.Text = "Next";

            TextBox pageField = new TextBox();
            pageField.Location = new Point(352, 435);
            pageField.Size = new Size(48, 22);
            pageField.Text = page.ToString();

            viewpanel.Controls.Add(grid);
            viewpanel.Controls.Add(prevBtn);
            viewpanel.Controls.Add(nxtBtn);
            viewpanel.Controls.Add(pageField);
            viewpanel.Controls.Add(lbl);
            viewpanel.Refresh();
        }
        void PrintAgentsDbResults(int page)
        {
            if (page < 0)
                return;
            currentPageIndex = page;
            currentTab = Tab.Agent;
            HideAllPanels();
            viewpanel.Visible = true;
            CleanViewPanel();

            List<Agent> agents = DBManager.Instance.GetAgents((page * 10), ((page + 1) * 10));

            DataGridView grid = new DataGridView();
            grid.Location = new Point(31, 48);
            grid.Size = new Size(716, 317);
            grid.Columns.Add("id", "id");
            grid.Columns.Add("username", "username");
            grid.Columns.Add("password", "password");
            grid.Columns.Add("commissionRate", "commissionRate");
            grid.Columns.Add("phoneNumber", "phoneNumber");
            grid.Columns.Add("address", "address");
            grid.Columns.Add("totalEarnedCommission", "totalEarnedCommission");
            grid.Columns.Add("created_at", "created_at");

            Label lbl = new Label();
            lbl.Text = "Viewing Agents";
            lbl.Location = new Point(25, 16);
            lbl.AutoSize = true;

            foreach (Agent agent in agents)
            {
                grid.Rows.Add(agent.id,agent.username,agent.password, agent.commissionRate, agent.phoneNumber,agent.address, agent.totalEarnedCommission,agent.created_at);
            }

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Button prevBtn = new Button();
            prevBtn.Click += prevPage_Click_1;
            prevBtn.Location = new Point(273, 435);
            prevBtn.Size = new Size(75, 23);
            prevBtn.Text = "Previous";

            Button nxtBtn = new Button();
            nxtBtn.Click += nxtPage_Click_1;
            nxtBtn.Location = new Point(406, 435);
            nxtBtn.Size = new Size(75, 23);
            nxtBtn.Text = "Next";

            TextBox pageField = new TextBox();
            pageField.Location = new Point(352, 435);
            pageField.Size = new Size(48, 22);
            pageField.Text = page.ToString();

            viewpanel.Controls.Add(grid);
            viewpanel.Controls.Add(prevBtn);
            viewpanel.Controls.Add(nxtBtn);
            viewpanel.Controls.Add(pageField);
            viewpanel.Controls.Add(lbl);
            viewpanel.Refresh();
        }

        private void nxtPage_Click_1(object sender, EventArgs e)
        {
            switch (currentTab)
            {
                case Tab.Client:
                    PrintClientsDbResults(currentPageIndex + 1);
                    break;
                case Tab.Property:
                    PrintPropertiesDbResults(currentPageIndex + 1);
                    break;
                case Tab.Contract:
                    PrintContractsDbResults(currentPageIndex + 1);
                    break;
                case Tab.Agent:
                    PrintAgentsDbResults(currentPageIndex + 1);
                    break;
                default:
                    break;
            }
        }
        private void prevPage_Click_1(object sender, EventArgs e)
        {
            switch (currentTab)
            {
                case Tab.Client:
                    PrintClientsDbResults(currentPageIndex - 1);
                    break;
                case Tab.Property:
                    PrintPropertiesDbResults(currentPageIndex - 1);
                    break;
                case Tab.Contract:
                    PrintContractsDbResults(currentPageIndex - 1);
                    break;
                case Tab.Agent:
                    PrintAgentsDbResults(currentPageIndex - 1);
                    break;
                default:
                    break;
            }
        }

        void AnalyzeUnderratedProperties()
        {
            HideAllPanels();
            analyzepanel.Visible = true;
            CleanAnalyzePanel();
            List<Property> properties = DBManager.Instance.GetUnderratedProperties();

            DataGridView grid = new DataGridView();
            grid.Location = new Point(31, 48);
            grid.Size = new Size(716, 317);
            grid.Columns.Add("id", "id");
            grid.Columns.Add("price", "price");
            grid.Columns.Add("roomNumber", "roomNumber");
            grid.Columns.Add("type", "type");
            grid.Columns.Add("address", "address");
            grid.Columns.Add("listing date", "listing date");
            grid.Columns.Add("feedback Rating", "Feedback Rating");

            Label lbl = new Label();
            lbl.Text = "Properties not sold within 90 days";
            lbl.Location = new Point(15, 16);
            lbl.AutoSize = true;

            foreach (Property property in properties)
            {
                grid.Rows.Add(property.id,property.price,property.roomNumber,property.type,property.address,property.listingDate.ToString(),property.feedbackRating);
            }

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            analyzepanel.Controls.Add(grid);
            analyzepanel.Controls.Add(lbl);
        }

        private void underratedPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnalyzeUnderratedProperties();
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPropertiesDbResults(0);
        }

        private void contractsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintContractsDbResults(0);
        }

        private void agentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintAgentsDbResults(0);
        }

        private void searchPropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendSearchPropertyMenu();
        }
        private void SendSearchPropertyMenu()
        {
            HideAllPanels();
            searchpropertypr.Visible = true;
            CleanAnalyzePanel();
        }

        private void SendSearchPropertyResults()
        {
            HideAllPanels();
            analyzepanel.Visible = true;
            CleanAnalyzePanel();

            int min; int max;
            try
            {
                min = Convert.ToInt32(minPropertyRange.Text);
                max = Convert.ToInt32(maxPropertyRange.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show("The values entered are invalid. Please enter valid arguments\n" +
                    e.Message);
                return;
            }

            List<Property> properties = DBManager.Instance.SearchProperty(min, max);

            DataGridView grid = new DataGridView();
            grid.Location = new Point(31, 48);
            grid.Size = new Size(716, 317);
            grid.Columns.Add("id", "id");
            grid.Columns.Add("price", "price");
            grid.Columns.Add("roomNumber", "roomNumber");
            grid.Columns.Add("type", "type");
            grid.Columns.Add("address", "address");
            grid.Columns.Add("listing date", "listing date");
            grid.Columns.Add("feedback Rating", "Feedback Rating");

            Label lbl = new Label();
            lbl.Text = $"Properties priced between {min} - {max}";
            lbl.Location = new Point(15, 16);
            lbl.AutoSize = true;

            foreach (Property property in properties)
            {
                grid.Rows.Add(property.id, property.price, property.roomNumber, property.type, property.address, property.listingDate.ToString(), property.feedbackRating);
            }

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            analyzepanel.Controls.Add(grid);
            analyzepanel.Controls.Add(lbl);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SendSearchPropertyResults();
        }
        private void SendCommissionTotal()
        {
            HideAllPanels();
            analyzepanel.Visible = true;
            CleanAnalyzePanel();

            int totalCommission = DBManager.Instance.GetTotalCommissionEarned();

            Label lbl = new Label();
            lbl.Text = $"Total Earned Commission";
            lbl.Location = new Point(15, 16);
            lbl.AutoSize = true;

            Label commission = new Label();
            commission.Text = $"Total Earned Commission: {totalCommission}$";
            commission.Location = new Point(165, 182);
            commission.TextAlign = ContentAlignment.MiddleCenter;
            commission.Font = new Font(commission.Font.FontFamily, 16f, commission.Font.Style);
            commission.AutoSize = true;


            analyzepanel.Controls.Add(lbl);
            analyzepanel.Controls.Add(commission);

        }

        private void totalCommissionEarnedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendCommissionTotal();
        }
    }
}
