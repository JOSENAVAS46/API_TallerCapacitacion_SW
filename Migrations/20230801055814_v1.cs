using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_TallerCapacitacion_SW.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Participantes_ParticipanteId",
                table: "Asistencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Talleres_TallerId",
                table: "Asistencias");

            migrationBuilder.DropTable(
                name: "ParticipanteTaller");

            migrationBuilder.DropIndex(
                name: "IX_Asistencias_ParticipanteId",
                table: "Asistencias");

            migrationBuilder.DropIndex(
                name: "IX_Asistencias_TallerId",
                table: "Asistencias");

            migrationBuilder.AddColumn<int>(
                name: "TallerId",
                table: "Participantes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_TallerId",
                table: "Participantes",
                column: "TallerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Talleres_TallerId",
                table: "Participantes",
                column: "TallerId",
                principalTable: "Talleres",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Talleres_TallerId",
                table: "Participantes");

            migrationBuilder.DropIndex(
                name: "IX_Participantes_TallerId",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "TallerId",
                table: "Participantes");

            migrationBuilder.CreateTable(
                name: "ParticipanteTaller",
                columns: table => new
                {
                    ParticipanteId = table.Column<int>(type: "int", nullable: false),
                    TallerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipanteTaller", x => new { x.ParticipanteId, x.TallerId });
                    table.ForeignKey(
                        name: "FK_ParticipanteTaller_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipanteTaller_Talleres_TallerId",
                        column: x => x.TallerId,
                        principalTable: "Talleres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_ParticipanteId",
                table: "Asistencias",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_TallerId",
                table: "Asistencias",
                column: "TallerId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipanteTaller_TallerId",
                table: "ParticipanteTaller",
                column: "TallerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Participantes_ParticipanteId",
                table: "Asistencias",
                column: "ParticipanteId",
                principalTable: "Participantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Talleres_TallerId",
                table: "Asistencias",
                column: "TallerId",
                principalTable: "Talleres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
