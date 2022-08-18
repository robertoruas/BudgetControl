using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetControl.Infrastructure.Persistence.Migrations
{
    public partial class Add_Categoryregisters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Despesas em geral com alimentação.", "Alimentação", (byte)1 },
                    { 2, "Despesas em geral com saúde.", "Saúde", (byte)1 },
                    { 3, "Despesas em geral com moradia.", "Moraria", (byte)1 },
                    { 4, "Despesas em geral com transporte.", "Transporte", (byte)1 },
                    { 5, "Despesas em geral com educação.", "Educação", (byte)1 },
                    { 6, "Despesas em geral com lazer.", "Lazer", (byte)1 },
                    { 7, "Despesas em geral com imprevistos.", "Imprevistos", (byte)1 },
                    { 8, "Outras despesas não previstas.", "Outras", (byte)1 },
                    { 9, "Salário recebido.", "Salário", (byte)0 },
                    { 10, "Renda extra realizada e remunerada.", "Freelance", (byte)0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
