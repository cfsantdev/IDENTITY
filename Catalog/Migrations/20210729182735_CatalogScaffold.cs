using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Migrations
{
    public partial class CatalogScaffold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Profile",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Insertion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Change = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_Profile_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "public",
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Insertion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 29, 15, 27, 34, 772, DateTimeKind.Local).AddTicks(6345)),
                    Change = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Name = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Profile_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "public",
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Insertion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 29, 15, 27, 34, 770, DateTimeKind.Local).AddTicks(8299)),
                    Change = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Name = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Profile_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "public",
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Insertion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 29, 15, 27, 34, 774, DateTimeKind.Local).AddTicks(64)),
                    Change = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Name = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_Profile_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "public",
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelItemCategory",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Insertion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 29, 15, 27, 34, 773, DateTimeKind.Local).AddTicks(3191)),
                    Change = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelItemCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelItemCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "public",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelItemCategory_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "public",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelItemCategory_Profile_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "public",
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelItemSection",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    SectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Insertion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 29, 15, 27, 34, 774, DateTimeKind.Local).AddTicks(5463)),
                    Change = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelItemSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelItemSection_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "public",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelItemSection_Profile_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "public",
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelItemSection_Section_SectionId",
                        column: x => x.SectionId,
                        principalSchema: "public",
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Name",
                schema: "public",
                table: "Category",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_OwnerId",
                schema: "public",
                table: "Category",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Name",
                schema: "public",
                table: "Item",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_OwnerId",
                schema: "public",
                table: "Item",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_OwnerId",
                schema: "public",
                table: "Profile",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RelItemCategory_CategoryId",
                schema: "public",
                table: "RelItemCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RelItemCategory_ItemId",
                schema: "public",
                table: "RelItemCategory",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RelItemCategory_OwnerId",
                schema: "public",
                table: "RelItemCategory",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RelItemSection_ItemId",
                schema: "public",
                table: "RelItemSection",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RelItemSection_OwnerId",
                schema: "public",
                table: "RelItemSection",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RelItemSection_SectionId",
                schema: "public",
                table: "RelItemSection",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_Name",
                schema: "public",
                table: "Section",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Section_OwnerId",
                schema: "public",
                table: "Section",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelItemCategory",
                schema: "public");

            migrationBuilder.DropTable(
                name: "RelItemSection",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Item",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Section",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Profile",
                schema: "public");
        }
    }
}
