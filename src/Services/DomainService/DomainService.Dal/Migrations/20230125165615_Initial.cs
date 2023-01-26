using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DomainService.Dal.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Country",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Country", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Province",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Province", x => x.Id);
                table.ForeignKey(
                    name: "FK_Province_Country_CountryId",
                    column: x => x.CountryId,
                    principalTable: "Country",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "User",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                EmailValue = table.Column<string>(name: "Email_Value", type: "character varying(256)", maxLength: 256, nullable: false),
                PasswordValue = table.Column<string>(name: "Password_Value", type: "character varying(256)", maxLength: 256, nullable: false),
                ProvinceId = table.Column<Guid>(type: "uuid", nullable: true),
                IsAgreeWorkForFood = table.Column<bool>(type: "boolean", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_User", x => x.Id);
                table.ForeignKey(
                    name: "FK_User_Province_ProvinceId",
                    column: x => x.ProvinceId,
                    principalTable: "Province",
                    principalColumn: "Id");
            });

        migrationBuilder.InsertData(
            table: "Country",
            columns: new[] { "Id", "CreatedOn", "Name", "UpdatedOn" },
            values: new object[,]
            {
                { new Guid("2357538a-fb77-483c-b74d-193d3381e067"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(689), "Canada", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(690) },
                { new Guid("2d21c50c-f170-4fcb-af22-db320c190193"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(687), "Botswana", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(688) },
                { new Guid("54a4811c-01d9-4f8f-8057-d3cc9abb3c31"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(691), "Dominica", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(691) },
                { new Guid("6816ee4a-91f3-4cae-a5c3-3285ee87db0d"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(682), "Angola", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(682) }
            });

        migrationBuilder.InsertData(
            table: "Province",
            columns: new[] { "Id", "CountryId", "CreatedOn", "Name", "UpdatedOn" },
            values: new object[,]
            {
                { new Guid("0ab8ec37-d69c-4ffd-a145-2c9d425177fe"), new Guid("2d21c50c-f170-4fcb-af22-db320c190193"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(733), "Mochudi2", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(733) },
                { new Guid("0b2457eb-871c-4a55-8284-2886723d81af"), new Guid("6816ee4a-91f3-4cae-a5c3-3285ee87db0d"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(708), "Malanje", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(708) },
                { new Guid("0c11f6cf-f351-457f-88df-6ba85f8c5d06"), new Guid("6816ee4a-91f3-4cae-a5c3-3285ee87db0d"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(701), "Huambo", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(701) },
                { new Guid("0fba0d27-436b-4875-88d9-7d60716815f3"), new Guid("2357538a-fb77-483c-b74d-193d3381e067"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(754), "Ramotswa", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(755) },
                { new Guid("10e4d238-0535-4643-b235-ab8b50657abd"), new Guid("2d21c50c-f170-4fcb-af22-db320c190193"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(726), "Malanje", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(726) },
                { new Guid("137c69c7-7c73-4be4-947b-3e4630b6191a"), new Guid("2d21c50c-f170-4fcb-af22-db320c190193"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(723), "Jwaneng", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(723) },
                { new Guid("20b36f86-e588-473b-836a-447b8afc5589"), new Guid("54a4811c-01d9-4f8f-8057-d3cc9abb3c31"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(777), "Moxico", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(777) },
                { new Guid("216ec99a-fa63-4b96-8e63-c2e2098b4f6b"), new Guid("2357538a-fb77-483c-b74d-193d3381e067"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(742), "Gaborone", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(742) },
                { new Guid("3122d8cf-aa94-4672-a062-207473aa14d0"), new Guid("2357538a-fb77-483c-b74d-193d3381e067"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(756), "Mochudi", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(756) },
                { new Guid("3ecf9f54-c39d-43a5-a965-3beb55662435"), new Guid("2d21c50c-f170-4fcb-af22-db320c190193"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(739), "Mochudids", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(739) },
                { new Guid("48591b8f-9c5a-4553-9a98-11ddf224d0f9"), new Guid("54a4811c-01d9-4f8f-8057-d3cc9abb3c31"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(780), "Soufrière", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(780) },
                { new Guid("52d55d06-39e3-47ee-ad31-06a037d45fd6"), new Guid("6816ee4a-91f3-4cae-a5c3-3285ee87db0d"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(712), "Bengo23", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(712) },
                { new Guid("548d2988-2ded-48e8-b644-7d60783bedf2"), new Guid("2357538a-fb77-483c-b74d-193d3381e067"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(763), "Mochudids", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(763) },
                { new Guid("5be29c4a-8d2d-4408-b4af-252c04740c53"), new Guid("6816ee4a-91f3-4cae-a5c3-3285ee87db0d"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(694), "Bengo", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(695) },
                { new Guid("5c0420cd-679b-49ff-a864-4381041ba37a"), new Guid("2357538a-fb77-483c-b74d-193d3381e067"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(760), "Mochudi3", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(760) },
                { new Guid("671bdb0f-3209-4bf6-b7d8-c5b46f97042c"), new Guid("2d21c50c-f170-4fcb-af22-db320c190193"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(719), "Francistown", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(720) },
                { new Guid("6d9c1649-cf61-46c3-8a66-a06da942bf60"), new Guid("54a4811c-01d9-4f8f-8057-d3cc9abb3c31"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(775), "Pointe Michel", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(776) },
                { new Guid("740e742f-35b6-4fd4-a42d-fb965a474d01"), new Guid("2357538a-fb77-483c-b74d-193d3381e067"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(761), "Mochudias", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(762) },
                { new Guid("754d8eff-ba27-486a-8535-6ca72b9223d1"), new Guid("6816ee4a-91f3-4cae-a5c3-3285ee87db0d"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(697), "Cuanza Sul", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(698) },
                { new Guid("7c6008df-0327-4d20-9b59-dc9eee9f5e4e"), new Guid("54a4811c-01d9-4f8f-8057-d3cc9abb3c31"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(772), "Portsmouth", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(772) },
                { new Guid("7f76919e-2ec9-474d-9e3e-2fa7324ff6ad"), new Guid("2357538a-fb77-483c-b74d-193d3381e067"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(743), "Cuanza Sul", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(744) },
                { new Guid("7fdf47b4-788d-49ff-ac5a-2c42f659d4dc"), new Guid("2d21c50c-f170-4fcb-af22-db320c190193"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(716), "Gaborone", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(716) },
                { new Guid("85116026-ba51-4cec-b539-eeac2ed56a29"), new Guid("6816ee4a-91f3-4cae-a5c3-3285ee87db0d"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(699), "Cunene", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(699) },
                { new Guid("8841be8f-b368-4d51-abb3-8526d148ba89"), new Guid("2d21c50c-f170-4fcb-af22-db320c190193"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(734), "Mochudi3", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(735) },
                { new Guid("8ec1304f-d749-4d37-aca8-9cd68bd129a0"), new Guid("2d21c50c-f170-4fcb-af22-db320c190193"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(737), "Mochudias", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(738) },
                { new Guid("99b5cbf1-bab5-473a-8245-07b9945f3225"), new Guid("54a4811c-01d9-4f8f-8057-d3cc9abb3c31"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(769), "Castle Bruce", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(769) },
                { new Guid("9b522774-696e-42cc-83ac-ebab319bdb07"), new Guid("2d21c50c-f170-4fcb-af22-db320c190193"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(731), "Mochudi", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(731) },
                { new Guid("a13ebfe7-ae4d-4bb7-9b40-731244a24fba"), new Guid("2357538a-fb77-483c-b74d-193d3381e067"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(748), "Orapa", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(749) },
                { new Guid("a158e2fd-edeb-4fc8-bec1-fac607783c80"), new Guid("2357538a-fb77-483c-b74d-193d3381e067"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(747), "Jwaneng", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(747) },
                { new Guid("b0f867e0-cad8-4a80-8e2d-67150d1ed2a3"), new Guid("2d21c50c-f170-4fcb-af22-db320c190193"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(724), "Orapa", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(724) },
                { new Guid("be0bf73c-2ae5-4e49-9b4c-983596835a18"), new Guid("2357538a-fb77-483c-b74d-193d3381e067"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(751), "Malanje", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(752) },
                { new Guid("c3d9d664-8e16-4df0-adfd-97955ba85b88"), new Guid("6816ee4a-91f3-4cae-a5c3-3285ee87db0d"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(704), "Luanda", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(705) },
                { new Guid("c9f9a5c3-433a-49bb-b57a-c63fab7a9cf7"), new Guid("2d21c50c-f170-4fcb-af22-db320c190193"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(718), "Cuanza Sul", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(718) },
                { new Guid("d18372bb-c0e2-439c-86b7-39be2be70322"), new Guid("6816ee4a-91f3-4cae-a5c3-3285ee87db0d"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(714), "Namibe", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(714) },
                { new Guid("d5b08d0a-f49e-49f1-91a8-002433ae9d0e"), new Guid("54a4811c-01d9-4f8f-8057-d3cc9abb3c31"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(767), "Marigot", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(768) },
                { new Guid("d7f44f5f-ea1b-4e17-9cb1-87315caba86a"), new Guid("54a4811c-01d9-4f8f-8057-d3cc9abb3c31"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(781), "Berekua", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(782) },
                { new Guid("d936d8c5-eef9-429e-a602-d2181437c7ae"), new Guid("2d21c50c-f170-4fcb-af22-db320c190193"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(727), "Kanye", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(728) },
                { new Guid("da5273a6-794f-4841-958f-e3a0494aa3cd"), new Guid("2d21c50c-f170-4fcb-af22-db320c190193"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(729), "Ramotswa", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(729) },
                { new Guid("e7438ca0-b960-46b2-92ec-b3db2b135590"), new Guid("2d21c50c-f170-4fcb-af22-db320c190193"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(740), "Mochudixc", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(741) },
                { new Guid("ee0d1243-e724-4c36-a1a5-809600833e3b"), new Guid("6816ee4a-91f3-4cae-a5c3-3285ee87db0d"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(709), "Moxico", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(709) },
                { new Guid("ef13fb36-0ec5-46c5-b8b1-7fce884d0d81"), new Guid("2357538a-fb77-483c-b74d-193d3381e067"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(745), "Francistown", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(746) },
                { new Guid("f683baa7-26a7-4859-925b-636493685127"), new Guid("2357538a-fb77-483c-b74d-193d3381e067"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(758), "Mochudi2", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(758) },
                { new Guid("f89e8221-c6e9-4972-ada6-836ed5ff4d2b"), new Guid("2357538a-fb77-483c-b74d-193d3381e067"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(766), "Mochudixc", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(766) },
                { new Guid("faa67e87-6666-4592-b589-0a1ebf7635d6"), new Guid("54a4811c-01d9-4f8f-8057-d3cc9abb3c31"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(774), "Saint Joseph", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(774) },
                { new Guid("fcb6667b-c680-41a1-864d-1206101b596c"), new Guid("54a4811c-01d9-4f8f-8057-d3cc9abb3c31"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(771), "Roseau", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(771) },
                { new Guid("fd3cc87e-6c3e-44cf-8c4f-f16dcd51d534"), new Guid("2357538a-fb77-483c-b74d-193d3381e067"), new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(753), "Kanye", new DateTime(2023, 1, 25, 16, 56, 15, 692, DateTimeKind.Utc).AddTicks(753) }
            });

        migrationBuilder.CreateIndex(
            name: "IX_Province_CountryId",
            table: "Province",
            column: "CountryId");

        migrationBuilder.CreateIndex(
            name: "IX_User_ProvinceId",
            table: "User",
            column: "ProvinceId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "User");

        migrationBuilder.DropTable(
            name: "Province");

        migrationBuilder.DropTable(
            name: "Country");
    }
}
