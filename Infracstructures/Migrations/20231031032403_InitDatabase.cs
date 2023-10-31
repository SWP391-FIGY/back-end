using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infracstructures.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CageStatus = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cage", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NutritionalIngredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageCondition = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    StandardPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Spiece",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Habitat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spiece", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bird",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirdImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirdStatus = table.Column<int>(type: "int", nullable: false),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpieceID = table.Column<int>(type: "int", nullable: false),
                    CageID = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bird", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bird_Cage_CageID",
                        column: x => x.CageID,
                        principalTable: "Cage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bird_Spiece_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Spiece",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MealMenu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirdStatus = table.Column<int>(type: "int", nullable: false),
                    MenuStatus = table.Column<int>(type: "int", nullable: false),
                    NutritionalIngredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeceID = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealMenu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MealMenu_Spiece_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Spiece",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatorID = table.Column<int>(type: "int", nullable: false),
                    PRID = table.Column<int>(type: "int", nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: true),
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_PurchaseOrder_PurchaseOrderID",
                        column: x => x.PurchaseOrderID,
                        principalTable: "PurchaseOrder",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_User_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CageID = table.Column<int>(type: "int", nullable: false),
                    BirdID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Log_Bird_BirdID",
                        column: x => x.BirdID,
                        principalTable: "Bird",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Log_Cage_CageID",
                        column: x => x.CageID,
                        principalTable: "Cage",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirdID = table.Column<int>(type: "int", nullable: false),
                    CageID = table.Column<int>(type: "int", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Task_Bird_BirdID",
                        column: x => x.BirdID,
                        principalTable: "Bird",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Task_Cage_CageID",
                        column: x => x.CageID,
                        principalTable: "Cage",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Task_User_StaffID",
                        column: x => x.StaffID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeedingPlan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeedingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirdID = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    MealMenuID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedingPlan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FeedingPlan_Bird_BirdID",
                        column: x => x.BirdID,
                        principalTable: "Bird",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedingPlan_MealMenu_MealMenuID",
                        column: x => x.MealMenuID,
                        principalTable: "MealMenu",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MenuDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    FoodID = table.Column<int>(type: "int", nullable: false),
                    MealMenuID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MenuDetail_Food_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Food",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuDetail_MealMenu_MealMenuID",
                        column: x => x.MealMenuID,
                        principalTable: "MealMenu",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    NetPrice = table.Column<int>(type: "int", nullable: false),
                    DeliverDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: false),
                    FoodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetail_Food_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Food",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetail_PurchaseOrder_PurchaseOrderID",
                        column: x => x.PurchaseOrderID,
                        principalTable: "PurchaseOrder",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequest",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorID = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: true),
                    ManagerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PurchaseRequest_PurchaseOrder_PurchaseOrderID",
                        column: x => x.PurchaseOrderID,
                        principalTable: "PurchaseOrder",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PurchaseRequest_User_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequestDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PurchaseRequestID = table.Column<int>(type: "int", nullable: false),
                    FoodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequestDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestDetail_Food_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Food",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestDetail_PurchaseRequest_PurchaseRequestID",
                        column: x => x.PurchaseRequestID,
                        principalTable: "PurchaseRequest",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bird_CageID",
                table: "Bird",
                column: "CageID");

            migrationBuilder.CreateIndex(
                name: "IX_Bird_SpeciesId",
                table: "Bird",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedingPlan_BirdID",
                table: "FeedingPlan",
                column: "BirdID");

            migrationBuilder.CreateIndex(
                name: "IX_FeedingPlan_MealMenuID",
                table: "FeedingPlan",
                column: "MealMenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Log_BirdID",
                table: "Log",
                column: "BirdID");

            migrationBuilder.CreateIndex(
                name: "IX_Log_CageID",
                table: "Log",
                column: "CageID");

            migrationBuilder.CreateIndex(
                name: "IX_MealMenu_SpeciesId",
                table: "MealMenu",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuDetail_FoodID",
                table: "MenuDetail",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuDetail_MealMenuID",
                table: "MenuDetail",
                column: "MealMenuID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_ManagerID",
                table: "PurchaseOrder",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_PurchaseOrderID",
                table: "PurchaseOrder",
                column: "PurchaseOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetail_FoodID",
                table: "PurchaseOrderDetail",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetail_PurchaseOrderID",
                table: "PurchaseOrderDetail",
                column: "PurchaseOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequest_ManagerID",
                table: "PurchaseRequest",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequest_PurchaseOrderID",
                table: "PurchaseRequest",
                column: "PurchaseOrderID",
                unique: true,
                filter: "[PurchaseOrderID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestDetail_FoodID",
                table: "PurchaseRequestDetail",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestDetail_PurchaseRequestID",
                table: "PurchaseRequestDetail",
                column: "PurchaseRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_BirdID",
                table: "Task",
                column: "BirdID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_CageID",
                table: "Task",
                column: "CageID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_StaffID",
                table: "Task",
                column: "StaffID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedingPlan");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "MenuDetail");

            migrationBuilder.DropTable(
                name: "PurchaseOrderDetail");

            migrationBuilder.DropTable(
                name: "PurchaseRequestDetail");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "MealMenu");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "PurchaseRequest");

            migrationBuilder.DropTable(
                name: "Bird");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "Cage");

            migrationBuilder.DropTable(
                name: "Spiece");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
