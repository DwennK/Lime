namespace ReportLibrary
{
	partial class Facture
	{
		#region Component Designer generated code
		/// <summary>
		/// Required method for telerik Reporting designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Facture));
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup3 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup4 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup5 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup6 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup7 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup8 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup9 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup10 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector1 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector2 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.dataSource1 = new Telerik.Reporting.SqlDataSource();
            this.dataSource2 = new Telerik.Reporting.SqlDataSource();
            this.pageHeaderSection = new Telerik.Reporting.PageHeaderSection();
            this.invoiceInfoPanel = new Telerik.Reporting.Panel();
            this.invoiceHeaderTextBox = new Telerik.Reporting.TextBox();
            this.invoiceNumberHeaderTextBox = new Telerik.Reporting.TextBox();
            this.invoiceNrTextBox = new Telerik.Reporting.TextBox();
            this.invoiceDateHeaderTextBox = new Telerik.Reporting.TextBox();
            this.invoiceDateTextBox = new Telerik.Reporting.TextBox();
            this.pagesHeaderTextBox = new Telerik.Reporting.TextBox();
            this.pagesTextBox = new Telerik.Reporting.TextBox();
            this.panel1 = new Telerik.Reporting.Panel();
            this.companyNameTextBox = new Telerik.Reporting.TextBox();
            this.billtoShipToPanel = new Telerik.Reporting.Panel();
            this.billToPanel = new Telerik.Reporting.Panel();
            this.billToHeaderTextBox = new Telerik.Reporting.TextBox();
            this.billToNameTextBox = new Telerik.Reporting.TextBox();
            this.billToAddressTextBox = new Telerik.Reporting.TextBox();
            this.billToPhoneTextBox = new Telerik.Reporting.TextBox();
            this.detailSection1 = new Telerik.Reporting.DetailSection();
            this.detailsTable = new Telerik.Reporting.Table();
            this.unitPriceTextBox = new Telerik.Reporting.TextBox();
            this.lineTotalTextBox = new Telerik.Reporting.TextBox();
            this.qtyTextBox = new Telerik.Reporting.TextBox();
            this.itemDescriptionTextBox = new Telerik.Reporting.TextBox();
            this.itemNrTextBox = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.unitDiscountLabelTextBox = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.unitDiscountTextBox = new Telerik.Reporting.TextBox();
            this.unitTaxLabelTextBox = new Telerik.Reporting.TextBox();
            this.unitTaxTextBox = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.totalLabelTextBox = new Telerik.Reporting.TextBox();
            this.totalTextBox = new Telerik.Reporting.TextBox();
            this.ItemNoHeaderTextBox = new Telerik.Reporting.TextBox();
            this.descriptionHeaderTextBox = new Telerik.Reporting.TextBox();
            this.qtyHeaderTextBox = new Telerik.Reporting.TextBox();
            this.unitPriceHeaderTextBox = new Telerik.Reporting.TextBox();
            this.lineTotalHeaderTextBox = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.pageFooterTextBox = new Telerik.Reporting.TextBox();
            this.companyLogoPictureBox = new Telerik.Reporting.PictureBox();
            this.shipToPhoneTextBox = new Telerik.Reporting.TextBox();
            this.shipToAddressTextBox = new Telerik.Reporting.TextBox();
            this.shipToNameTextBox = new Telerik.Reporting.TextBox();
            this.shipToHeaderTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // dataSource1
            // 
            this.dataSource1.ConnectionString = "ReportLibrary.Properties.Settings.Alias";
            this.dataSource1.Name = "dataSource1";
            this.dataSource1.SelectCommand = resources.GetString("dataSource1.SelectCommand");
            // 
            // dataSource2
            // 
            this.dataSource2.ConnectionString = "ReportLibrary.Properties.Settings.Alias";
            this.dataSource2.Name = "dataSource2";
            this.dataSource2.SelectCommand = resources.GetString("dataSource2.SelectCommand");
            // 
            // pageHeaderSection
            // 
            this.pageHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(2.598D);
            this.pageHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.invoiceInfoPanel,
            this.billtoShipToPanel,
            this.shipToHeaderTextBox,
            this.shipToAddressTextBox,
            this.shipToNameTextBox,
            this.shipToPhoneTextBox});
            this.pageHeaderSection.Name = "pageHeaderSection";
            // 
            // invoiceInfoPanel
            // 
            this.invoiceInfoPanel.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.invoiceHeaderTextBox,
            this.invoiceNumberHeaderTextBox,
            this.invoiceNrTextBox,
            this.invoiceDateHeaderTextBox,
            this.invoiceDateTextBox,
            this.pagesHeaderTextBox,
            this.pagesTextBox,
            this.panel1});
            this.invoiceInfoPanel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.invoiceInfoPanel.Name = "invoiceInfoPanel";
            this.invoiceInfoPanel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.9D), Telerik.Reporting.Drawing.Unit.Cm(3.6D));
            // 
            // invoiceHeaderTextBox
            // 
            this.invoiceHeaderTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.502D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.invoiceHeaderTextBox.Name = "invoiceHeaderTextBox";
            this.invoiceHeaderTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.398D), Telerik.Reporting.Drawing.Unit.Cm(1.001D));
            this.invoiceHeaderTextBox.Style.Font.Bold = true;
            this.invoiceHeaderTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(22D);
            this.invoiceHeaderTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.invoiceHeaderTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.invoiceHeaderTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.invoiceHeaderTextBox.Value = "INVOICE";
            // 
            // invoiceNumberHeaderTextBox
            // 
            this.invoiceNumberHeaderTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9D), Telerik.Reporting.Drawing.Unit.Cm(1.403D));
            this.invoiceNumberHeaderTextBox.Name = "invoiceNumberHeaderTextBox";
            this.invoiceNumberHeaderTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6D), Telerik.Reporting.Drawing.Unit.Cm(0.599D));
            this.invoiceNumberHeaderTextBox.Style.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.invoiceNumberHeaderTextBox.Style.BorderColor.Default = System.Drawing.Color.Silver;
            this.invoiceNumberHeaderTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.invoiceNumberHeaderTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.invoiceNumberHeaderTextBox.Style.Color = System.Drawing.Color.DimGray;
            this.invoiceNumberHeaderTextBox.Style.Font.Bold = true;
            this.invoiceNumberHeaderTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.invoiceNumberHeaderTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.invoiceNumberHeaderTextBox.Value = "INVOICE NO";
            // 
            // invoiceNrTextBox
            // 
            this.invoiceNrTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.5D), Telerik.Reporting.Drawing.Unit.Cm(1.403D));
            this.invoiceNrTextBox.Name = "invoiceNrTextBox";
            this.invoiceNrTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.4D), Telerik.Reporting.Drawing.Unit.Cm(0.599D));
            this.invoiceNrTextBox.Style.BorderColor.Default = System.Drawing.Color.Silver;
            this.invoiceNrTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.invoiceNrTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.invoiceNrTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.2D);
            this.invoiceNrTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.invoiceNrTextBox.Value = "=Fields.[Numero]";
            // 
            // invoiceDateHeaderTextBox
            // 
            this.invoiceDateHeaderTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9D), Telerik.Reporting.Drawing.Unit.Cm(2.002D));
            this.invoiceDateHeaderTextBox.Name = "invoiceDateHeaderTextBox";
            this.invoiceDateHeaderTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6D), Telerik.Reporting.Drawing.Unit.Cm(0.599D));
            this.invoiceDateHeaderTextBox.Style.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.invoiceDateHeaderTextBox.Style.BorderColor.Default = System.Drawing.Color.Silver;
            this.invoiceDateHeaderTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.invoiceDateHeaderTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.invoiceDateHeaderTextBox.Style.Color = System.Drawing.Color.DimGray;
            this.invoiceDateHeaderTextBox.Style.Font.Bold = true;
            this.invoiceDateHeaderTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.invoiceDateHeaderTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.invoiceDateHeaderTextBox.Value = "DATE";
            // 
            // invoiceDateTextBox
            // 
            this.invoiceDateTextBox.Format = "{0:d}";
            this.invoiceDateTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.5D), Telerik.Reporting.Drawing.Unit.Cm(2.002D));
            this.invoiceDateTextBox.Name = "invoiceDateTextBox";
            this.invoiceDateTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.399D), Telerik.Reporting.Drawing.Unit.Cm(0.599D));
            this.invoiceDateTextBox.Style.BorderColor.Default = System.Drawing.Color.Silver;
            this.invoiceDateTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.invoiceDateTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.invoiceDateTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.2D);
            this.invoiceDateTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.invoiceDateTextBox.Value = "=Fields.[DateCreation]";
            // 
            // pagesHeaderTextBox
            // 
            this.pagesHeaderTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9D), Telerik.Reporting.Drawing.Unit.Cm(2.601D));
            this.pagesHeaderTextBox.Name = "pagesHeaderTextBox";
            this.pagesHeaderTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6D), Telerik.Reporting.Drawing.Unit.Cm(0.598D));
            this.pagesHeaderTextBox.Style.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.pagesHeaderTextBox.Style.BorderColor.Default = System.Drawing.Color.Silver;
            this.pagesHeaderTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pagesHeaderTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.pagesHeaderTextBox.Style.Color = System.Drawing.Color.DimGray;
            this.pagesHeaderTextBox.Style.Font.Bold = true;
            this.pagesHeaderTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.pagesHeaderTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.pagesHeaderTextBox.Value = "PAGE";
            // 
            // pagesTextBox
            // 
            this.pagesTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.5D), Telerik.Reporting.Drawing.Unit.Cm(2.601D));
            this.pagesTextBox.Name = "pagesTextBox";
            this.pagesTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.399D), Telerik.Reporting.Drawing.Unit.Cm(0.598D));
            this.pagesTextBox.Style.BorderColor.Default = System.Drawing.Color.Silver;
            this.pagesTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pagesTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.pagesTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.2D);
            this.pagesTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.pagesTextBox.Value = "{[PageNumber]} of {[PageCount]}";
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.companyNameTextBox});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.1D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.26D), Telerik.Reporting.Drawing.Unit.Cm(0.701D));
            // 
            // companyNameTextBox
            // 
            this.companyNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.companyNameTextBox.Name = "companyNameTextBox";
            this.companyNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.26D), Telerik.Reporting.Drawing.Unit.Cm(0.7D));
            this.companyNameTextBox.Style.Font.Bold = true;
            this.companyNameTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16D);
            this.companyNameTextBox.Value = "Microwest Informatique";
            // 
            // billtoShipToPanel
            // 
            this.billtoShipToPanel.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.billToPanel});
            this.billtoShipToPanel.KeepTogether = false;
            this.billtoShipToPanel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.001D), Telerik.Reporting.Drawing.Unit.Cm(4.1D));
            this.billtoShipToPanel.Name = "billtoShipToPanel";
            this.billtoShipToPanel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.26D), Telerik.Reporting.Drawing.Unit.Cm(2.3D));
            // 
            // billToPanel
            // 
            this.billToPanel.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.billToHeaderTextBox,
            this.billToNameTextBox,
            this.billToAddressTextBox,
            this.billToPhoneTextBox});
            this.billToPanel.KeepTogether = false;
            this.billToPanel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.billToPanel.Name = "billToPanel";
            this.billToPanel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.259D), Telerik.Reporting.Drawing.Unit.Cm(2.201D));
            this.billToPanel.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.billToPanel.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Cm(0.2D);
            // 
            // billToHeaderTextBox
            // 
            this.billToHeaderTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.billToHeaderTextBox.Name = "billToHeaderTextBox";
            this.billToHeaderTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.259D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.billToHeaderTextBox.Style.Color = System.Drawing.Color.DimGray;
            this.billToHeaderTextBox.Style.Font.Bold = true;
            this.billToHeaderTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.billToHeaderTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.billToHeaderTextBox.Value = "Adresse de Facturation";
            // 
            // billToNameTextBox
            // 
            this.billToNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.billToNameTextBox.Name = "billToNameTextBox";
            this.billToNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.259D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.billToNameTextBox.TextWrap = false;
            this.billToNameTextBox.Value = "=Fields.[Nom]";
            // 
            // billToAddressTextBox
            // 
            this.billToAddressTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(1.001D));
            this.billToAddressTextBox.Name = "billToAddressTextBox";
            this.billToAddressTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.259D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.billToAddressTextBox.TextWrap = false;
            this.billToAddressTextBox.Value = "=Fields.[Adresse]";
            // 
            // billToPhoneTextBox
            // 
            this.billToPhoneTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(1.501D));
            this.billToPhoneTextBox.Name = "billToPhoneTextBox";
            this.billToPhoneTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.259D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.billToPhoneTextBox.TextWrap = false;
            this.billToPhoneTextBox.Value = "=Fields.[Telephone1]";
            // 
            // detailSection1
            // 
            this.detailSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(2.362D);
            this.detailSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detailsTable});
            this.detailSection1.Name = "detailSection1";
            this.detailSection1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            // 
            // detailsTable
            // 
            this.detailsTable.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.782D)));
            this.detailsTable.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(5.478D)));
            this.detailsTable.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.433D)));
            this.detailsTable.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(3.072D)));
            this.detailsTable.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(3.135D)));
            this.detailsTable.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.9D)));
            this.detailsTable.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(1D)));
            this.detailsTable.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(1D)));
            this.detailsTable.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(1D)));
            this.detailsTable.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(1D)));
            this.detailsTable.Body.SetCellContent(0, 3, this.unitPriceTextBox);
            this.detailsTable.Body.SetCellContent(0, 4, this.lineTotalTextBox);
            this.detailsTable.Body.SetCellContent(0, 2, this.qtyTextBox);
            this.detailsTable.Body.SetCellContent(0, 1, this.itemDescriptionTextBox);
            this.detailsTable.Body.SetCellContent(0, 0, this.itemNrTextBox);
            this.detailsTable.Body.SetCellContent(1, 0, this.textBox1);
            this.detailsTable.Body.SetCellContent(1, 1, this.textBox2);
            this.detailsTable.Body.SetCellContent(1, 2, this.textBox3);
            this.detailsTable.Body.SetCellContent(2, 0, this.textBox6);
            this.detailsTable.Body.SetCellContent(2, 1, this.textBox8);
            this.detailsTable.Body.SetCellContent(2, 2, this.textBox10);
            this.detailsTable.Body.SetCellContent(3, 0, this.textBox14);
            this.detailsTable.Body.SetCellContent(3, 1, this.textBox15);
            this.detailsTable.Body.SetCellContent(3, 2, this.textBox16);
            this.detailsTable.Body.SetCellContent(2, 3, this.unitDiscountLabelTextBox);
            this.detailsTable.Body.SetCellContent(1, 3, this.textBox12);
            this.detailsTable.Body.SetCellContent(1, 4, this.textBox4);
            this.detailsTable.Body.SetCellContent(2, 4, this.unitDiscountTextBox);
            this.detailsTable.Body.SetCellContent(3, 3, this.unitTaxLabelTextBox);
            this.detailsTable.Body.SetCellContent(3, 4, this.unitTaxTextBox);
            this.detailsTable.Body.SetCellContent(4, 0, this.textBox5);
            this.detailsTable.Body.SetCellContent(4, 1, this.textBox13);
            this.detailsTable.Body.SetCellContent(4, 2, this.textBox17);
            this.detailsTable.Body.SetCellContent(4, 3, this.totalLabelTextBox);
            this.detailsTable.Body.SetCellContent(4, 4, this.totalTextBox);
            tableGroup1.ReportItem = this.ItemNoHeaderTextBox;
            tableGroup2.ReportItem = this.descriptionHeaderTextBox;
            tableGroup3.ReportItem = this.qtyHeaderTextBox;
            tableGroup4.ReportItem = this.unitPriceHeaderTextBox;
            tableGroup5.Name = "group1";
            tableGroup5.ReportItem = this.lineTotalHeaderTextBox;
            this.detailsTable.ColumnGroups.Add(tableGroup1);
            this.detailsTable.ColumnGroups.Add(tableGroup2);
            this.detailsTable.ColumnGroups.Add(tableGroup3);
            this.detailsTable.ColumnGroups.Add(tableGroup4);
            this.detailsTable.ColumnGroups.Add(tableGroup5);
            this.detailsTable.ColumnHeadersPrintOnEveryPage = true;
            this.detailsTable.DataSource = this.dataSource2;
            this.detailsTable.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.itemNrTextBox,
            this.itemDescriptionTextBox,
            this.qtyTextBox,
            this.unitPriceTextBox,
            this.lineTotalTextBox,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox12,
            this.textBox4,
            this.textBox6,
            this.textBox8,
            this.textBox10,
            this.unitDiscountLabelTextBox,
            this.unitDiscountTextBox,
            this.textBox14,
            this.textBox15,
            this.textBox16,
            this.unitTaxLabelTextBox,
            this.unitTaxTextBox,
            this.textBox5,
            this.textBox13,
            this.textBox17,
            this.totalLabelTextBox,
            this.totalTextBox,
            this.ItemNoHeaderTextBox,
            this.descriptionHeaderTextBox,
            this.qtyHeaderTextBox,
            this.unitPriceHeaderTextBox,
            this.lineTotalHeaderTextBox});
            this.detailsTable.KeepTogether = false;
            this.detailsTable.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.499D));
            this.detailsTable.Name = "detailsTable";
            tableGroup6.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup6.Name = "Detail";
            tableGroup7.Name = "group3";
            tableGroup8.Name = "group4";
            tableGroup9.Name = "group5";
            tableGroup10.Name = "group6";
            this.detailsTable.RowGroups.Add(tableGroup6);
            this.detailsTable.RowGroups.Add(tableGroup7);
            this.detailsTable.RowGroups.Add(tableGroup8);
            this.detailsTable.RowGroups.Add(tableGroup9);
            this.detailsTable.RowGroups.Add(tableGroup10);
            this.detailsTable.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.899D), Telerik.Reporting.Drawing.Unit.Cm(5.5D));
            this.detailsTable.Style.BorderColor.Bottom = System.Drawing.Color.Black;
            this.detailsTable.Style.BorderColor.Default = System.Drawing.Color.Silver;
            this.detailsTable.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.detailsTable.StyleName = "Normal.TableNormal";
            // 
            // unitPriceTextBox
            // 
            this.unitPriceTextBox.Format = "{0:C2}";
            this.unitPriceTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.unitPriceTextBox.Name = "unitPriceTextBox";
            this.unitPriceTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.072D), Telerik.Reporting.Drawing.Unit.Cm(0.9D));
            this.unitPriceTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.2D);
            this.unitPriceTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.unitPriceTextBox.StyleName = "Normal.TableBody";
            this.unitPriceTextBox.Value = "=Fields.[Ligne_PrixUniteTTC]";
            // 
            // lineTotalTextBox
            // 
            this.lineTotalTextBox.Format = "{0:C2}";
            this.lineTotalTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.lineTotalTextBox.Name = "lineTotalTextBox";
            this.lineTotalTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.135D), Telerik.Reporting.Drawing.Unit.Cm(0.9D));
            this.lineTotalTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.lineTotalTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.lineTotalTextBox.StyleName = "Normal.TableBody";
            this.lineTotalTextBox.Value = "=(Fields.[Ligne_Quantite] * Fields.[Ligne_PrixUniteTTC])";
            // 
            // qtyTextBox
            // 
            this.qtyTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.qtyTextBox.Name = "qtyTextBox";
            this.qtyTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.433D), Telerik.Reporting.Drawing.Unit.Cm(0.9D));
            this.qtyTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.qtyTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.qtyTextBox.StyleName = "Normal.TableBody";
            this.qtyTextBox.Value = "=Fields.[Ligne_Quantite]";
            // 
            // itemDescriptionTextBox
            // 
            this.itemDescriptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.itemDescriptionTextBox.Name = "itemDescriptionTextBox";
            this.itemDescriptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.478D), Telerik.Reporting.Drawing.Unit.Cm(0.9D));
            this.itemDescriptionTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.itemDescriptionTextBox.StyleName = "Normal.TableBody";
            this.itemDescriptionTextBox.Value = "=Fields.[Ligne_Libelle]";
            // 
            // itemNrTextBox
            // 
            this.itemNrTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.itemNrTextBox.Name = "itemNrTextBox";
            this.itemNrTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.782D), Telerik.Reporting.Drawing.Unit.Cm(0.9D));
            this.itemNrTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.itemNrTextBox.StyleName = "Normal.TableBody";
            this.itemNrTextBox.Value = "=Fields.[Ligne_ID]";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.782D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.textBox1.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox1.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox1.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.textBox1.StyleName = "Normal.TableBody";
            this.textBox1.Value = "";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.478D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.textBox2.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox2.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox2.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.textBox2.StyleName = "Normal.TableBody";
            this.textBox2.Value = "";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.433D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.textBox3.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.textBox3.StyleName = "Normal.TableBody";
            this.textBox3.Value = "";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.782D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.textBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox6.StyleName = "Normal.TableBody";
            this.textBox6.Value = "";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.478D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.textBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox8.StyleName = "Normal.TableBody";
            this.textBox8.Value = "";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.433D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.textBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox10.StyleName = "Normal.TableBody";
            this.textBox10.Value = "";
            // 
            // textBox14
            // 
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.782D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.textBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.StyleName = "Normal.TableBody";
            this.textBox14.Value = "";
            // 
            // textBox15
            // 
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.478D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.textBox15.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox15.StyleName = "Normal.TableBody";
            this.textBox15.Value = "";
            // 
            // textBox16
            // 
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.433D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.textBox16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox16.StyleName = "Normal.TableBody";
            this.textBox16.Value = "";
            // 
            // unitDiscountLabelTextBox
            // 
            this.unitDiscountLabelTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.unitDiscountLabelTextBox.Name = "unitDiscountLabelTextBox";
            this.unitDiscountLabelTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.072D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.unitDiscountLabelTextBox.Style.BorderColor.Default = System.Drawing.Color.Silver;
            this.unitDiscountLabelTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.unitDiscountLabelTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.unitDiscountLabelTextBox.Style.Font.Bold = false;
            this.unitDiscountLabelTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.unitDiscountLabelTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.unitDiscountLabelTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.unitDiscountLabelTextBox.StyleName = "Normal.TableBody";
            this.unitDiscountLabelTextBox.Value = "Discount";
            // 
            // textBox12
            // 
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.072D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.textBox12.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox12.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.textBox12.Style.Font.Bold = true;
            this.textBox12.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.StyleName = "Normal.TableBody";
            this.textBox12.Value = "Sub Total";
            // 
            // textBox4
            // 
            this.textBox4.Format = "{0:C2}";
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.135D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.textBox4.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.StyleName = "Normal.TableBody";
            this.textBox4.Value = "=Sum(Fields.[Ligne_PrixUniteTTC] * Fields.[Ligne_Quantite])";
            // 
            // unitDiscountTextBox
            // 
            this.unitDiscountTextBox.Format = "{0:C2}";
            this.unitDiscountTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.unitDiscountTextBox.Name = "unitDiscountTextBox";
            this.unitDiscountTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.135D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.unitDiscountTextBox.Style.BorderColor.Default = System.Drawing.Color.Silver;
            this.unitDiscountTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.unitDiscountTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.unitDiscountTextBox.Style.Font.Bold = false;
            this.unitDiscountTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.unitDiscountTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.unitDiscountTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.unitDiscountTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.unitDiscountTextBox.StyleName = "Normal.TableBody";
            this.unitDiscountTextBox.Value = "=Sum(Fields.[Ligne_Quantite] * Fields.[Ligne_TauxRemise])";
            // 
            // unitTaxLabelTextBox
            // 
            this.unitTaxLabelTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.unitTaxLabelTextBox.Name = "unitTaxLabelTextBox";
            this.unitTaxLabelTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.072D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.unitTaxLabelTextBox.Style.BorderColor.Default = System.Drawing.Color.Silver;
            this.unitTaxLabelTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.unitTaxLabelTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.unitTaxLabelTextBox.Style.Font.Bold = false;
            this.unitTaxLabelTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.unitTaxLabelTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.unitTaxLabelTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.unitTaxLabelTextBox.StyleName = "Normal.TableBody";
            this.unitTaxLabelTextBox.Value = "Tax";
            // 
            // unitTaxTextBox
            // 
            this.unitTaxTextBox.Format = "{0:C2}";
            this.unitTaxTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.unitTaxTextBox.Name = "unitTaxTextBox";
            this.unitTaxTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.135D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.unitTaxTextBox.Style.BorderColor.Default = System.Drawing.Color.Silver;
            this.unitTaxTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.unitTaxTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.unitTaxTextBox.Style.Font.Bold = false;
            this.unitTaxTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.unitTaxTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.unitTaxTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.unitTaxTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.unitTaxTextBox.StyleName = "Normal.TableBody";
            this.unitTaxTextBox.Value = "=Sum(Fields.[Ligne_Quantite] * Fields.[Ligne_TotalTVA])";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.782D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.textBox5.StyleName = "Normal.TableTotal";
            this.textBox5.Value = "";
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.478D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.textBox13.StyleName = "Normal.TableTotal";
            this.textBox13.Value = "";
            // 
            // textBox17
            // 
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.433D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.textBox17.StyleName = "Normal.TableTotal";
            this.textBox17.Value = "";
            // 
            // totalLabelTextBox
            // 
            this.totalLabelTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.totalLabelTextBox.Name = "totalLabelTextBox";
            this.totalLabelTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.072D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.totalLabelTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.totalLabelTextBox.StyleName = "Normal.TableTotal";
            this.totalLabelTextBox.Value = "TOTAL";
            // 
            // totalTextBox
            // 
            this.totalTextBox.Format = "{0:C2}";
            this.totalTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.135D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.totalTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.totalTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.totalTextBox.StyleName = "Normal.TableTotal";
            this.totalTextBox.Value = "=(Sum(Fields.[Ligne_PrixUniteTTC] * Fields.[Ligne_Quantite]) - Sum(Fields.[Ligne_" +
    "Quantite] * Fields.[Ligne_TauxRemise]) + Sum(Fields.[Ligne_Quantite] * Fields.[L" +
    "igne_TotalTVA]))";
            // 
            // ItemNoHeaderTextBox
            // 
            this.ItemNoHeaderTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.ItemNoHeaderTextBox.Name = "ItemNoHeaderTextBox";
            this.ItemNoHeaderTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.782D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.ItemNoHeaderTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.ItemNoHeaderTextBox.StyleName = "Normal.TableHeader";
            this.ItemNoHeaderTextBox.Value = "No";
            // 
            // descriptionHeaderTextBox
            // 
            this.descriptionHeaderTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.descriptionHeaderTextBox.Name = "descriptionHeaderTextBox";
            this.descriptionHeaderTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.478D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.descriptionHeaderTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.descriptionHeaderTextBox.StyleName = "Normal.TableHeader";
            this.descriptionHeaderTextBox.Value = "DESCRIPTION";
            // 
            // qtyHeaderTextBox
            // 
            this.qtyHeaderTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.qtyHeaderTextBox.Name = "qtyHeaderTextBox";
            this.qtyHeaderTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.433D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.qtyHeaderTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.qtyHeaderTextBox.StyleName = "Normal.TableHeader";
            this.qtyHeaderTextBox.Value = "QTY";
            // 
            // unitPriceHeaderTextBox
            // 
            this.unitPriceHeaderTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.unitPriceHeaderTextBox.Name = "unitPriceHeaderTextBox";
            this.unitPriceHeaderTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.072D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.unitPriceHeaderTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.unitPriceHeaderTextBox.StyleName = "Normal.TableHeader";
            this.unitPriceHeaderTextBox.Value = "UNIT PRICE";
            // 
            // lineTotalHeaderTextBox
            // 
            this.lineTotalHeaderTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.lineTotalHeaderTextBox.Name = "lineTotalHeaderTextBox";
            this.lineTotalHeaderTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.135D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.lineTotalHeaderTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            this.lineTotalHeaderTextBox.StyleName = "Normal.TableHeader";
            this.lineTotalHeaderTextBox.Value = "LINE TOTAL";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.102D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageFooterTextBox,
            this.companyLogoPictureBox});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // pageFooterTextBox
            // 
            this.pageFooterTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.7D), Telerik.Reporting.Drawing.Unit.Cm(1.073D));
            this.pageFooterTextBox.Name = "pageFooterTextBox";
            this.pageFooterTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.2D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.pageFooterTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.pageFooterTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageFooterTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.pageFooterTextBox.Value = "Thank you for your business!";
            // 
            // companyLogoPictureBox
            // 
            this.companyLogoPictureBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.001D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.companyLogoPictureBox.MimeType = "image/png";
            this.companyLogoPictureBox.Name = "companyLogoPictureBox";
            this.companyLogoPictureBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.761D), Telerik.Reporting.Drawing.Unit.Cm(2.8D));
            this.companyLogoPictureBox.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.companyLogoPictureBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.companyLogoPictureBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.companyLogoPictureBox.Value = ((object)(resources.GetObject("companyLogoPictureBox.Value")));
            // 
            // shipToPhoneTextBox
            // 
            this.shipToPhoneTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.259D), Telerik.Reporting.Drawing.Unit.Cm(5.601D));
            this.shipToPhoneTextBox.Name = "shipToPhoneTextBox";
            this.shipToPhoneTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.941D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.shipToPhoneTextBox.TextWrap = false;
            this.shipToPhoneTextBox.Value = "=Fields.[Telephone1]";
            // 
            // shipToAddressTextBox
            // 
            this.shipToAddressTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.259D), Telerik.Reporting.Drawing.Unit.Cm(5.1D));
            this.shipToAddressTextBox.Name = "shipToAddressTextBox";
            this.shipToAddressTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.941D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.shipToAddressTextBox.TextWrap = false;
            this.shipToAddressTextBox.Value = "=Fields.[Adresse]";
            // 
            // shipToNameTextBox
            // 
            this.shipToNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.259D), Telerik.Reporting.Drawing.Unit.Cm(4.6D));
            this.shipToNameTextBox.Name = "shipToNameTextBox";
            this.shipToNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.941D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.shipToNameTextBox.TextWrap = false;
            this.shipToNameTextBox.Value = "=Fields.[Nom]";
            // 
            // shipToHeaderTextBox
            // 
            this.shipToHeaderTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.259D), Telerik.Reporting.Drawing.Unit.Cm(4.1D));
            this.shipToHeaderTextBox.Name = "shipToHeaderTextBox";
            this.shipToHeaderTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.941D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.shipToHeaderTextBox.Style.Color = System.Drawing.Color.DimGray;
            this.shipToHeaderTextBox.Style.Font.Bold = true;
            this.shipToHeaderTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.shipToHeaderTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.shipToHeaderTextBox.Value = "Adresse de Livraison";
            // 
            // Facture
            // 
            this.Culture = new System.Globalization.CultureInfo("fr-CH");
            this.DataSource = this.dataSource1;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection,
            this.detailSection1,
            this.pageFooterSection1});
            this.Name = "Invoice1";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            descendantSelector1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Table)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "Normal.TableHeader")});
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector1});
            styleRule3.Style.BackgroundColor = System.Drawing.Color.Gainsboro;
            styleRule3.Style.BorderColor.Default = System.Drawing.Color.Silver;
            styleRule3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(1D);
            styleRule3.Style.Color = System.Drawing.Color.DimGray;
            styleRule3.Style.Font.Bold = true;
            styleRule3.Style.Font.Name = "Arial";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule3.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            descendantSelector2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Table)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "Normal.TableBody")});
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector2});
            styleRule4.Style.BorderColor.Default = System.Drawing.Color.Silver;
            styleRule4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(1D);
            styleRule4.Style.Font.Name = "Arial";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            styleRule4.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule5.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Normal.TableTotal")});
            styleRule5.Style.BackgroundColor = System.Drawing.Color.Silver;
            styleRule5.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule5.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule5.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(1D);
            styleRule5.Style.Font.Bold = true;
            styleRule5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            styleRule5.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.3D);
            styleRule5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            styleRule5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4,
            styleRule5});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(16.518D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

            }
        #endregion

        private Telerik.Reporting.SqlDataSource dataSource1;
        private Telerik.Reporting.SqlDataSource dataSource2;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection;
        private Telerik.Reporting.Panel invoiceInfoPanel;
        private Telerik.Reporting.TextBox invoiceHeaderTextBox;
        private Telerik.Reporting.TextBox invoiceNumberHeaderTextBox;
        private Telerik.Reporting.TextBox invoiceNrTextBox;
        private Telerik.Reporting.TextBox invoiceDateHeaderTextBox;
        private Telerik.Reporting.TextBox invoiceDateTextBox;
        private Telerik.Reporting.TextBox pagesHeaderTextBox;
        private Telerik.Reporting.TextBox pagesTextBox;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.TextBox companyNameTextBox;
        private Telerik.Reporting.Panel billtoShipToPanel;
        private Telerik.Reporting.Panel billToPanel;
        private Telerik.Reporting.TextBox billToHeaderTextBox;
        private Telerik.Reporting.TextBox billToNameTextBox;
        private Telerik.Reporting.TextBox billToAddressTextBox;
        private Telerik.Reporting.TextBox billToPhoneTextBox;
        private Telerik.Reporting.DetailSection detailSection1;
        private Telerik.Reporting.Table detailsTable;
        private Telerik.Reporting.TextBox unitPriceTextBox;
        private Telerik.Reporting.TextBox lineTotalTextBox;
        private Telerik.Reporting.TextBox qtyTextBox;
        private Telerik.Reporting.TextBox itemDescriptionTextBox;
        private Telerik.Reporting.TextBox itemNrTextBox;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox unitDiscountLabelTextBox;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox unitDiscountTextBox;
        private Telerik.Reporting.TextBox unitTaxLabelTextBox;
        private Telerik.Reporting.TextBox unitTaxTextBox;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox totalLabelTextBox;
        private Telerik.Reporting.TextBox totalTextBox;
        private Telerik.Reporting.TextBox ItemNoHeaderTextBox;
        private Telerik.Reporting.TextBox descriptionHeaderTextBox;
        private Telerik.Reporting.TextBox qtyHeaderTextBox;
        private Telerik.Reporting.TextBox unitPriceHeaderTextBox;
        private Telerik.Reporting.TextBox lineTotalHeaderTextBox;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox pageFooterTextBox;
        private Telerik.Reporting.PictureBox companyLogoPictureBox;
        private Telerik.Reporting.TextBox shipToHeaderTextBox;
        private Telerik.Reporting.TextBox shipToAddressTextBox;
        private Telerik.Reporting.TextBox shipToNameTextBox;
        private Telerik.Reporting.TextBox shipToPhoneTextBox;
    }
}