using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AjusteModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opcao_Pergunta_Order = 1",
                table: "Opcao");

            migrationBuilder.RenameColumn(
                name: "Order = 1",
                table: "Opcao",
                newName: "IdPergunta");

            migrationBuilder.RenameIndex(
                name: "IX_Opcao_Order = 1",
                table: "Opcao",
                newName: "IX_Opcao_IdPergunta");

            migrationBuilder.AlterColumn<int>(
                name: "IdResposta",
                table: "OpcaoResposta",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "IdOpcao",
                table: "OpcaoResposta",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Opcao_Pergunta_IdPergunta",
                table: "Opcao",
                column: "IdPergunta",
                principalTable: "Pergunta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opcao_Pergunta_IdPergunta",
                table: "Opcao");

            migrationBuilder.RenameColumn(
                name: "IdPergunta",
                table: "Opcao",
                newName: "Order = 1");

            migrationBuilder.RenameIndex(
                name: "IX_Opcao_IdPergunta",
                table: "Opcao",
                newName: "IX_Opcao_Order = 1");

            migrationBuilder.AlterColumn<int>(
                name: "IdResposta",
                table: "OpcaoResposta",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "IdOpcao",
                table: "OpcaoResposta",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Opcao_Pergunta_Order = 1",
                table: "Opcao",
                column: "Order = 1",
                principalTable: "Pergunta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
