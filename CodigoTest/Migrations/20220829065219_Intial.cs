using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldCities.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "colours");

            migrationBuilder.DropTable(
                name: "CustomizeCode");

            migrationBuilder.DropTable(
                name: "FinanceCategories");

            migrationBuilder.DropTable(
                name: "Finances");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "PerformaInvoiceDetails");

            migrationBuilder.DropTable(
                name: "RawMaterials");

            migrationBuilder.DropTable(
                name: "RawSetups");

            migrationBuilder.DropTable(
                name: "RawStock");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "logId",
                table: "LogModels",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "logId",
                table: "LogModels",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "colours",
                columns: table => new
                {
                    colourID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    colourCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    colourName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colours", x => x.colourID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CustomerCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerMobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CustomerPaymentCurrency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "FinanceCategories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Finances",
                columns: table => new
                {
                    FinanceId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReminderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finances", x => x.FinanceId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactoryCompleteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsApproveFactory = table.Column<bool>(type: "bit", nullable: false),
                    IsApproveOffice = table.Column<bool>(type: "bit", nullable: false),
                    IsApproveOrder = table.Column<bool>(type: "bit", nullable: false),
                    OfficeCompleteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderApproveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderConfirmedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderFactoryUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    OrderOfficeUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderStep = table.Column<int>(type: "int", nullable: false),
                    POFocalperson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POFocalpersonEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationFocalperson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationFocalpersonEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "PerformaInvoiceDetails",
                columns: table => new
                {
                    OrderDetailID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerformaInvoiceNo = table.Column<int>(type: "int", nullable: false),
                    ProductAdjustmentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductQty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformaInvoiceDetails", x => x.OrderDetailID);
                });

            migrationBuilder.CreateTable(
                name: "RawMaterials",
                columns: table => new
                {
                    RawMaterialID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RawMaterialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RawMaterialQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RawMaterialTotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RawMaterialUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RawSetupID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterials", x => x.RawMaterialID);
                });

            migrationBuilder.CreateTable(
                name: "RawSetups",
                columns: table => new
                {
                    RawID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RawName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RawType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RawUnit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawSetups", x => x.RawID);
                });

            migrationBuilder.CreateTable(
                name: "RawStock",
                columns: table => new
                {
                    RawStockID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AssignUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceForOneUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RawSetupID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RawStockDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawStock", x => x.RawStockID);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductQty = table.Column<int>(type: "int", nullable: false),
                    StockDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockID);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SupplierAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierBankAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierBankInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierPaymentCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CBM = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CartoonLWH = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CartoonLWHCM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CategoryID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Colour = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Material = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OldProductCode = table.Column<int>(type: "int", nullable: true),
                    ProdictImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCode = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Shape = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    barcode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    heightInner = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    length = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    lengthInner = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    mpn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    pcsPerCtn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    width = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    widthInner = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomizeCode",
                columns: table => new
                {
                    CustomizeCodeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CustomerProductCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    HeightInner = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LengthInner = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WidthInner = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    customerId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    mpn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomizeCode", x => x.CustomizeCodeId);
                    table.ForeignKey(
                        name: "FK_CustomizeCode_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomizeCode_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProductAdjustmentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductOriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductQty = table.Column<int>(type: "int", nullable: false),
                    QuotationVersion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomizeCode_customerId",
                table: "CustomizeCode",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomizeCode_ProductId",
                table: "CustomizeCode",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductID",
                table: "OrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }
    }
}
