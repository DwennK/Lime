namespace Reports
{
    partial class Report1
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Drawing.FormattingRule formattingRule1 = new Telerik.Reporting.Drawing.FormattingRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report1));
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule6 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector1 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule7 = new Telerik.Reporting.Drawing.StyleRule();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.pageHeaderSection = new Telerik.Reporting.PageHeaderSection();
            this.pagesPageHeaderTextBox = new Telerik.Reporting.TextBox();
            this.detailSection = new Telerik.Reporting.DetailSection();
            this.productNameTextBox = new Telerik.Reporting.TextBox();
            this.reportHeaderSection = new Telerik.Reporting.ReportHeaderSection();
            this.companyNameTextBox = new Telerik.Reporting.TextBox();
            this.companyLogoPictureBox = new Telerik.Reporting.PictureBox();
            this.companyDetailsPanel = new Telerik.Reporting.Panel();
            this.reportFooterSection = new Telerik.Reporting.ReportFooterSection();
            this.totalTextBox = new Telerik.Reporting.TextBox();
            this.productGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.productGroupHeaderTextBox = new Telerik.Reporting.TextBox();
            this.productGroupHeaderPanel = new Telerik.Reporting.Panel();
            this.productNameHeaderTextBox = new Telerik.Reporting.TextBox();
            this.productGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.groupTotalTextBox = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.Prix = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Reports.Properties.Settings.LimeAppTest";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.SelectCommand = "SELECT        Articles.*\r\nFROM            Articles";
            // 
            // pageHeaderSection
            // 
            this.pageHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.5D);
            this.pageHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pagesPageHeaderTextBox});
            this.pageHeaderSection.Name = "pageHeaderSection";
            // 
            // pagesPageHeaderTextBox
            // 
            this.pagesPageHeaderTextBox.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Top | Telerik.Reporting.AnchoringStyles.Right)));
            this.pagesPageHeaderTextBox.Culture = new System.Globalization.CultureInfo("fr-CH");
            this.pagesPageHeaderTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.701D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.pagesPageHeaderTextBox.Name = "pagesPageHeaderTextBox";
            this.pagesPageHeaderTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.3D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.pagesPageHeaderTextBox.Style.Font.Bold = false;
            this.pagesPageHeaderTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.pagesPageHeaderTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pagesPageHeaderTextBox.Value = "Page {[PageNumber]} of {[PageCount]}";
            // 
            // detailSection
            // 
            formattingRule1.Filters.Add(new Telerik.Reporting.Filter("=RowNumber(\'ProductCatalogReport\')%2", Telerik.Reporting.FilterOperator.Equal, "=0"));
            formattingRule1.Style.BackgroundColor = System.Drawing.SystemColors.GrayText;
            this.detailSection.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.detailSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.8D);
            this.detailSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.productNameTextBox,
            this.Prix});
            this.detailSection.KeepTogether = false;
            this.detailSection.Name = "detailSection";
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.001D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.999D), Telerik.Reporting.Drawing.Unit.Cm(0.8D));
            this.productNameTextBox.StyleName = "Normal.DetailBody";
            this.productNameTextBox.Value = "=Fields.[Libelle]";
            // 
            // reportHeaderSection
            // 
            this.reportHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(3.001D);
            this.reportHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.companyNameTextBox,
            this.companyLogoPictureBox,
            this.companyDetailsPanel});
            this.reportHeaderSection.Name = "reportHeaderSection";
            // 
            // companyNameTextBox
            // 
            this.companyNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.3D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.companyNameTextBox.Name = "companyNameTextBox";
            this.companyNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.7D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.companyNameTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(22D);
            this.companyNameTextBox.Value = "=Fields.[QuantiteStock]";
            // 
            // companyLogoPictureBox
            // 
            this.companyLogoPictureBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.companyLogoPictureBox.MimeType = "image/png";
            this.companyLogoPictureBox.Name = "companyLogoPictureBox";
            this.companyLogoPictureBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3D), Telerik.Reporting.Drawing.Unit.Cm(3.001D));
            this.companyLogoPictureBox.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.companyLogoPictureBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.companyLogoPictureBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.companyLogoPictureBox.Value = ((object)(resources.GetObject("companyLogoPictureBox.Value")));
            // 
            // companyDetailsPanel
            // 
            this.companyDetailsPanel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.34D), Telerik.Reporting.Drawing.Unit.Cm(1.003D));
            this.companyDetailsPanel.Name = "companyDetailsPanel";
            this.companyDetailsPanel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.66D), Telerik.Reporting.Drawing.Unit.Cm(0.001D));
            // 
            // reportFooterSection
            // 
            this.reportFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.8D);
            this.reportFooterSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.totalTextBox});
            this.reportFooterSection.Name = "reportFooterSection";
            this.reportFooterSection.Style.BackgroundColor = System.Drawing.Color.Gainsboro;
            // 
            // totalTextBox
            // 
            this.totalTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18D), Telerik.Reporting.Drawing.Unit.Cm(0.8D));
            this.totalTextBox.Style.Font.Bold = true;
            this.totalTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.totalTextBox.StyleName = "Report.GroupFooter";
            this.totalTextBox.Value = "TOTAL: {Count(Fields.[ID])} produits";
            // 
            // productGroupHeaderSection
            // 
            this.productGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(2.599D);
            this.productGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.productGroupHeaderTextBox,
            this.productGroupHeaderPanel});
            this.productGroupHeaderSection.Name = "productGroupHeaderSection";
            // 
            // productGroupHeaderTextBox
            // 
            this.productGroupHeaderTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.productGroupHeaderTextBox.Name = "productGroupHeaderTextBox";
            this.productGroupHeaderTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18D), Telerik.Reporting.Drawing.Unit.Cm(1.582D));
            this.productGroupHeaderTextBox.StyleName = "Report.GroupHeader";
            this.productGroupHeaderTextBox.Value = "=Fields.[ID_Marques]";
            // 
            // productGroupHeaderPanel
            // 
            this.productGroupHeaderPanel.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.productNameHeaderTextBox,
            this.textBox1});
            this.productGroupHeaderPanel.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.001D), Telerik.Reporting.Drawing.Unit.Cm(1.599D));
            this.productGroupHeaderPanel.Name = "productGroupHeaderPanel";
            this.productGroupHeaderPanel.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.productGroupHeaderPanel.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.productGroupHeaderPanel.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.productGroupHeaderPanel.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.productGroupHeaderPanel.StyleName = "";
            // 
            // productNameHeaderTextBox
            // 
            this.productNameHeaderTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.productNameHeaderTextBox.Name = "productNameHeaderTextBox";
            this.productNameHeaderTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.999D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.productNameHeaderTextBox.StyleName = "Normal.TableHeader";
            this.productNameHeaderTextBox.Value = "Produit";
            // 
            // productGroupFooterSection
            // 
            this.productGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.6D);
            this.productGroupFooterSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupTotalTextBox});
            this.productGroupFooterSection.Name = "productGroupFooterSection";
            // 
            // groupTotalTextBox
            // 
            this.groupTotalTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.groupTotalTextBox.Name = "groupTotalTextBox";
            this.groupTotalTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.groupTotalTextBox.Style.Font.Bold = true;
            this.groupTotalTextBox.StyleName = "Report.GroupFooter";
            this.groupTotalTextBox.Value = "{Fields.[ID_Marques]}: {Count(Fields.[ID])} produits";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.999D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.textBox1.StyleName = "Normal.TableHeader";
            this.textBox1.Value = "Prix";
            // 
            // Prix
            // 
            this.Prix.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(16D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.Prix.Name = "Prix";
            this.Prix.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2D), Telerik.Reporting.Drawing.Unit.Cm(0.8D));
            this.Prix.StyleName = "Normal.DetailBody";
            this.Prix.Value = "= Fields.PrixVente";
            // 
            // Report1
            // 
            this.DataSource = this.sqlDataSource1;
            group1.GroupFooter = this.productGroupFooterSection;
            group1.GroupHeader = this.productGroupHeaderSection;
            group1.Groupings.Add(new Telerik.Reporting.Grouping("=Fields.[ID_Marques]"));
            group1.Name = "productGroup";
            group1.Sortings.Add(new Telerik.Reporting.Sorting("=Fields.[ID_Marques]", Telerik.Reporting.SortDirection.Asc));
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.productGroupHeaderSection,
            this.productGroupFooterSection,
            this.pageHeaderSection,
            this.detailSection,
            this.reportHeaderSection,
            this.reportFooterSection});
            this.Name = "ProductCatalogReport";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.5D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule2.Style.Font.Name = "Segoe UI";
            styleRule2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(4D);
            styleRule2.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(4D);
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.TextBox), "Report.GroupHeader")});
            styleRule3.Style.Font.Bold = true;
            styleRule3.Style.Font.Name = "Cambria";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20D);
            styleRule3.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Cm(0.2D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.TextBox), "Report.SubGroupHeader")});
            styleRule4.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule4.Style.Font.Bold = true;
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule5.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.TextBox), "Normal.TableHeader")});
            styleRule5.Style.Font.Bold = false;
            styleRule5.Style.Font.Name = "Segoe UI Semibold";
            styleRule5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            styleRule5.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule5.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            descendantSelector1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Report)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "Normal.DetailBody")});
            styleRule6.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector1});
            styleRule6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            styleRule6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule7.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.TextItemBase), "Report.GroupFooter")});
            styleRule7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4,
            styleRule5,
            styleRule6,
            styleRule7});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(18.001D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection;
        private Telerik.Reporting.TextBox pagesPageHeaderTextBox;
        private Telerik.Reporting.DetailSection detailSection;
        private Telerik.Reporting.TextBox productNameTextBox;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection;
        private Telerik.Reporting.TextBox companyNameTextBox;
        private Telerik.Reporting.PictureBox companyLogoPictureBox;
        private Telerik.Reporting.Panel companyDetailsPanel;
        private Telerik.Reporting.ReportFooterSection reportFooterSection;
        private Telerik.Reporting.TextBox totalTextBox;
        private Telerik.Reporting.GroupHeaderSection productGroupHeaderSection;
        private Telerik.Reporting.TextBox productGroupHeaderTextBox;
        private Telerik.Reporting.Panel productGroupHeaderPanel;
        private Telerik.Reporting.TextBox productNameHeaderTextBox;
        private Telerik.Reporting.GroupFooterSection productGroupFooterSection;
        private Telerik.Reporting.TextBox groupTotalTextBox;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox Prix;
    }
}