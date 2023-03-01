using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable
#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreDB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "Franchises",
                columns: table => new
                {
                    FranchiseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchises", x => x.FranchiseId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReleaseYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TrailerUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FranchiseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Franchises_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchises",
                        principalColumn: "FranchiseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCharacters",
                columns: table => new
                {
                    CharactersCharacterId = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCharacters", x => new { x.CharactersCharacterId, x.MoviesMovieId });
                    table.ForeignKey(
                        name: "FK_MovieCharacters_Characters_CharactersCharacterId",
                        column: x => x.CharactersCharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCharacters_Movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterId", "Alias", "Gender", "MovieId", "Name", "PictureUrl" },
                values: new object[,]
                {
                    { 1, "Iron Man", "Male", 1, "Iron Man (Tony Stark)", "https://www.imdb.com/HeDiedInVain" },
                    { 2, "The Fatherless One", "Male", 2, "Luke Skywalker", "https://www.imdb.com/title/IamNotYourDaddy" },
                    { 3, "The Chosen One", "Male", 3, "Harry Potter", "https://www.imdb.com/title/itsWingardiumLeviOsaNotLeviOsa" }
                });

            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "FranchiseId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A series of superhero films produced by Marvel Studios", "Marvel Cinematic Universe" },
                    { 2, "An epic space-opera media franchise", "Star Wars" },
                    { 3, "A series of fantasy novels written by J. K. Rowling", "Harry Potter" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Director", "FranchiseId", "Genre", "PictureUrl", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[,]
                {
                    { 1, "Anthony Russo, Joe Russo", 1, "Action, Adventure, Sci-Fi", "https://www.imdb.com/TooDamnLongMovie", "2019", "Avengers: Endgame", "https://www.youtube.com/watch?v=TcMBFSGVi1c" },
                    { 2, "George Lucas", 2, "Action, Adventure, Fantasy", "https://www.imdb.com/WaveTheSaberMyFriend", "1977", "Star Wars: Episode IV - A New Hope", "https://www.youtube.com/watch?v=1g3_CFmnU7k" },
                    { 3, "Chris Columbus", 3, "Adventure, Family, Fantasy", "https://www.imdb.com/HarrysParrentDidNotLikeHim", "2001", "Harry Potter and the Philosopher's Stone", "https://www.youtube.com/watch?v=VyHV0BRtdxo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCharacters_MoviesMovieId",
                table: "MovieCharacters",
                column: "MoviesMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_FranchiseId",
                table: "Movies",
                column: "FranchiseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCharacters");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Franchises");
        }
    }
}
