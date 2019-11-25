using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabalhoWebV1.Migrations
{
    public partial class migracao_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desenvolvedors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true),
                    adm = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvedors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true),
                    dataEntrega = table.Column<DateTime>(nullable: false),
                    solicitante = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DesenvolvedorProjetos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DesenvolvedorId = table.Column<int>(nullable: false),
                    ProjetoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesenvolvedorProjetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesenvolvedorProjetos_Desenvolvedors_DesenvolvedorId",
                        column: x => x.DesenvolvedorId,
                        principalTable: "Desenvolvedors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesenvolvedorProjetos_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requisitos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dataCadastro = table.Column<DateTime>(nullable: false),
                    descricao = table.Column<string>(nullable: true),
                    observacoes = table.Column<string>(nullable: true),
                    dataEntrega = table.Column<DateTime>(nullable: false),
                    funcional = table.Column<bool>(nullable: false),
                    ProjetoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requisitos_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bugs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    desenvolvedorCriadorId = table.Column<int>(nullable: false),
                    desenvolvedorResolvedorId = table.Column<int>(nullable: false),
                    requisitoId = table.Column<int>(nullable: false),
                    descricao = table.Column<string>(nullable: true),
                    prioridade = table.Column<string>(nullable: true),
                    dataCadastro = table.Column<DateTime>(nullable: false),
                    resolvido = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bugs_Desenvolvedors_desenvolvedorCriadorId",
                        column: x => x.desenvolvedorCriadorId,
                        principalTable: "Desenvolvedors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bugs_Desenvolvedors_desenvolvedorResolvedorId",
                        column: x => x.desenvolvedorResolvedorId,
                        principalTable: "Desenvolvedors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bugs_Requisitos_requisitoId",
                        column: x => x.requisitoId,
                        principalTable: "Requisitos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DesenvolverdorRequisitos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DesenvolvedorId = table.Column<int>(nullable: false),
                    RequisitoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesenvolverdorRequisitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesenvolverdorRequisitos_Requisitos_RequisitoId",
                        column: x => x.RequisitoId,
                        principalTable: "Requisitos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_desenvolvedorCriadorId",
                table: "Bugs",
                column: "desenvolvedorCriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_desenvolvedorResolvedorId",
                table: "Bugs",
                column: "desenvolvedorResolvedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_requisitoId",
                table: "Bugs",
                column: "requisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_DesenvolvedorProjetos_DesenvolvedorId",
                table: "DesenvolvedorProjetos",
                column: "DesenvolvedorId");

            migrationBuilder.CreateIndex(
                name: "IX_DesenvolvedorProjetos_ProjetoId",
                table: "DesenvolvedorProjetos",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_DesenvolverdorRequisitos_RequisitoId",
                table: "DesenvolverdorRequisitos",
                column: "RequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitos_ProjetoId",
                table: "Requisitos",
                column: "ProjetoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bugs");

            migrationBuilder.DropTable(
                name: "DesenvolvedorProjetos");

            migrationBuilder.DropTable(
                name: "DesenvolverdorRequisitos");

            migrationBuilder.DropTable(
                name: "Desenvolvedors");

            migrationBuilder.DropTable(
                name: "Requisitos");

            migrationBuilder.DropTable(
                name: "Projetos");
        }
    }
}
