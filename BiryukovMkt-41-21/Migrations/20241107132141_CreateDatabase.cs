using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiryukovMkt_41_21.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cathedras",
                columns: table => new
                {
                    cathedra_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cathedra_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название кафедры"),
                    f_head_teacher_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор заведующего кафедрой")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cathedras", x => x.cathedra_id);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacher_firstname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    teacher_lastname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Фамилия преподавателя"),
                    teacher_middlename = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Отчество преподавателя"),
                    teacher_position = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Должность преподавателя"),
                    teacher_degree = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Ученая степень преподавателя"),
                    f_cathedra_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.teacher_id);
                    table.ForeignKey(
                        name: "FK_teachers_cathedras_f_cathedra_id",
                        column: x => x.f_cathedra_id,
                        principalTable: "cathedras",
                        principalColumn: "cathedra_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "disciplines",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи дисциплины")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discipline_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название дисциплины"),
                    f_teacher_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplines", x => x.discipline_id);
                    table.ForeignKey(
                        name: "FK_disciplines_teachers_f_teacher_id",
                        column: x => x.f_teacher_id,
                        principalTable: "teachers",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cathedras_f_head_teacher_id",
                table: "cathedras",
                column: "f_head_teacher_id",
                unique: true,
                filter: "[f_head_teacher_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_disciplines_f_teacher_id",
                table: "disciplines",
                column: "f_teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_teachers_f_cathedra_id",
                table: "teachers",
                column: "f_cathedra_id");

            migrationBuilder.AddForeignKey(
                name: "FK_cathedras_teachers_f_head_teacher_id",
                table: "cathedras",
                column: "f_head_teacher_id",
                principalTable: "teachers",
                principalColumn: "teacher_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cathedras_teachers_f_head_teacher_id",
                table: "cathedras");

            migrationBuilder.DropTable(
                name: "disciplines");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.DropTable(
                name: "cathedras");
        }
    }
}
