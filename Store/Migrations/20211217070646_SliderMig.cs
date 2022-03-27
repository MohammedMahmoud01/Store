using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class SliderMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbSlider",
                columns: table => new
                {
                    SliderId = table.Column<int>(type: "int", nullable: false),
                    SliderImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descreption = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LongDescreption = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbSlider", x => x.SliderId);
                });
      
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {      
            migrationBuilder.DropTable(
                name: "TbSlider");
        }
    }
}
