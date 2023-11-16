using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnalisisProyecto.Migrations
{
    /// <inheritdoc />
    public partial class CambioDuracionAString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classrooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    requirements = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    numeration = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__classroo__3213E83F5D82BCDE", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "computer_equipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    license_plate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    @class = table.Column<string>(name: "class", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    brand = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    model = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    state = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    observations = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    include = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    last_modifications = table.Column<DateTime>(type: "date", nullable: true),
                    serial_number = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    entry_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__computer__3213E83F8B66061B", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    units = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__inventor__3213E83F34C54636", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "loan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start_date = table.Column<DateTime>(type: "date", nullable: true),
                    end_date = table.Column<DateTime>(type: "date", nullable: true),
                    register_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__loan__3213E83F893123D6", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "privileges",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__privileg__3213E83F2DBC5980", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__role__3213E83F87D9164D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "study_room",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    capacity = table.Column<int>(type: "int", nullable: true),
                    isAvailable = table.Column<bool>(type: "bit", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__study_ro__3213E83FFC182EAC", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "titles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    publisher_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    header = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    term_subject = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    associated_date = table.Column<DateTime>(type: "date", nullable: true),
                    publication_date = table.Column<DateTime>(type: "date", nullable: true),
                    number = table.Column<int>(type: "int", nullable: true),
                    rest_title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    person_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ISBN = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    mention_responsibility = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    information = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    general_subject_subdivision = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__titles__3213E83F1E7D6FF8", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "classroom_schedule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    day = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    id_classroom = table.Column<int>(type: "int", nullable: true),
                    start_hour = table.Column<TimeSpan>(type: "time", nullable: true),
                    end_hour = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__classroo__3213E83FA5364179", x => x.id);
                    table.ForeignKey(
                        name: "FK__classroom__id_cl__6B24EA82",
                        column: x => x.id_classroom,
                        principalTable: "classrooms",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "area",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inventory_id = table.Column<int>(type: "int", nullable: true),
                    area = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__area__3213E83F204CAC68", x => x.id);
                    table.ForeignKey(
                        name: "FK__area__inventory___5165187F",
                        column: x => x.inventory_id,
                        principalTable: "inventory",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "inventory_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inventory_id = table.Column<int>(type: "int", nullable: true),
                    type = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__inventor__3213E83FCC7DC832", x => x.id);
                    table.ForeignKey(
                        name: "FK__inventory__inven__4E88ABD4",
                        column: x => x.inventory_id,
                        principalTable: "inventory",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "report_computer_equipment",
                columns: table => new
                {
                    id_computer_equipment = table.Column<int>(type: "int", nullable: true),
                    id_return_equipment = table.Column<int>(type: "int", nullable: true),
                    id_loan_equipment = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__report_co__id_co__6477ECF3",
                        column: x => x.id_computer_equipment,
                        principalTable: "computer_equipment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__report_co__id_lo__66603565",
                        column: x => x.id_loan_equipment,
                        principalTable: "loan",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__report_co__id_re__656C112C",
                        column: x => x.id_return_equipment,
                        principalTable: "computer_equipment",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "role_privileges",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_id = table.Column<int>(type: "int", nullable: true),
                    privileges_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__role_pri__3213E83F3B5BF317", x => x.id);
                    table.ForeignKey(
                        name: "FK__role_priv__privi__3F466844",
                        column: x => x.privileges_id,
                        principalTable: "privileges",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__role_priv__role___3E52440B",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "userr",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    category = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: true),
                    phone = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    career = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    last_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    creation_date = table.Column<DateTime>(type: "date", nullable: true),
                    deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__userr__3213E83F87C1CAD7", x => x.id);
                    table.ForeignKey(
                        name: "FK__userr__role_id__398D8EEE",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "furniture",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_study_room = table.Column<int>(type: "int", nullable: true),
                    furniture = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__furnitur__3213E83F43831C07", x => x.id);
                    table.ForeignKey(
                        name: "FK__furniture__furni__59063A47",
                        column: x => x.id_study_room,
                        principalTable: "study_room",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "study_room_schedule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    day = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    id_study_room = table.Column<int>(type: "int", nullable: true),
                    start_hour = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    end_hour = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__study_ro__3213E83F701452AA", x => x.id);
                    table.ForeignKey(
                        name: "FK__study_roo__id_st__5BE2A6F2",
                        column: x => x.id_study_room,
                        principalTable: "study_room",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "copy",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_titles = table.Column<int>(type: "int", nullable: true),
                    sequence = table.Column<int>(type: "int", nullable: true),
                    barcode = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    sub_library = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    classification = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    collection = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    item_status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    notes = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__copy__3213E83F154913F7", x => x.id);
                    table.ForeignKey(
                        name: "FK__copy__id_titles__628FA481",
                        column: x => x.id_titles,
                        principalTable: "titles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "library_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: true),
                    library = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    privilege = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    type_user = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__library___3213E83F8A2693CE", x => x.id);
                    table.ForeignKey(
                        name: "FK__library_u__id_us__4BAC3F29",
                        column: x => x.id_user,
                        principalTable: "userr",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "loan_book_log",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_users = table.Column<int>(type: "int", nullable: true),
                    id_loan = table.Column<int>(type: "int", nullable: true),
                    barcode = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    sub_library = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    penalty = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    hour = table.Column<TimeSpan>(type: "time", nullable: true),
                    expiration_date = table.Column<DateTime>(type: "date", nullable: true),
                    bibliographic_information = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__loan_boo__3213E83F2ED945BD", x => x.id);
                    table.ForeignKey(
                        name: "FK__loan_book__id_lo__5FB337D6",
                        column: x => x.id_loan,
                        principalTable: "loan",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__loan_book__id_us__5EBF139D",
                        column: x => x.id_users,
                        principalTable: "userr",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "loan_classrooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    id_loan = table.Column<int>(type: "int", nullable: true),
                    id_classroom = table.Column<int>(type: "int", nullable: true),
                    person_quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__loan_cla__3213E83F1C9FA5E6", x => x.id);
                    table.ForeignKey(
                        name: "FK__loan_clas__id_cl__7B5B524B",
                        column: x => x.id_classroom,
                        principalTable: "classrooms",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__loan_clas__id_lo__7A672E12",
                        column: x => x.id_loan,
                        principalTable: "loan",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__loan_clas__id_us__7C4F7684",
                        column: x => x.id,
                        principalTable: "userr",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "loan_field",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_loan = table.Column<int>(type: "int", nullable: true),
                    id_user = table.Column<int>(type: "int", nullable: true),
                    materials = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    lightning = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__loan_fie__3213E83F288E3255", x => x.id);
                    table.ForeignKey(
                        name: "FK__loan_fiel__id_lo__72C60C4A",
                        column: x => x.id_loan,
                        principalTable: "loan",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__loan_fiel__id_us__73BA3083",
                        column: x => x.id_user,
                        principalTable: "userr",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "loan_sports_equipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_loan = table.Column<int>(type: "int", nullable: true),
                    id_user = table.Column<int>(type: "int", nullable: true),
                    materials = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__loan_spo__3213E83FEE7317A0", x => x.id);
                    table.ForeignKey(
                        name: "FK__loan_spor__id_lo__76969D2E",
                        column: x => x.id_loan,
                        principalTable: "loan",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__loan_spor__id_us__778AC167",
                        column: x => x.id_user,
                        principalTable: "userr",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "loan_vehicle",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_loan = table.Column<int>(type: "int", nullable: true),
                    id_user = table.Column<int>(type: "int", nullable: true),
                    activity_type = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    responsible = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    state = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    destination = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    starting_place = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    exit_date = table.Column<DateTime>(type: "date", nullable: true),
                    return_date = table.Column<DateTime>(type: "date", nullable: true),
                    exit_hour = table.Column<TimeSpan>(type: "time", nullable: true),
                    return_hour = table.Column<TimeSpan>(type: "time", nullable: true),
                    register_date = table.Column<DateTime>(type: "date", nullable: true),
                    person_quantity = table.Column<int>(type: "int", nullable: true),
                    unity_or_carrer = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    assigned_vehicle = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__loan_veh__3213E83F5C45B1D1", x => x.id);
                    table.ForeignKey(
                        name: "FK__loan_vehi__id_lo__7E37BEF6",
                        column: x => x.id_loan,
                        principalTable: "loan",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__loan_vehi__id_us__7F2BE32F",
                        column: x => x.id_user,
                        principalTable: "userr",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "loan_books",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_loan = table.Column<int>(type: "int", nullable: true),
                    id_copy = table.Column<int>(type: "int", nullable: true),
                    id_library_user = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    photocopy_charge = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    sub_library = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    observation = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    limit_fines = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__loan_boo__3213E83FAF530B67", x => x.id);
                    table.ForeignKey(
                        name: "FK__loan_book__id_co__6EF57B66",
                        column: x => x.id_copy,
                        principalTable: "copy",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__loan_book__id_li__6FE99F9F",
                        column: x => x.id_library_user,
                        principalTable: "library_user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__loan_book__id_lo__6E01572D",
                        column: x => x.id_loan,
                        principalTable: "loan",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "loan_computer_equipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_computer_equipment = table.Column<int>(type: "int", nullable: true),
                    id_loan = table.Column<int>(type: "int", nullable: true),
                    id_library_user = table.Column<int>(type: "int", nullable: true),
                    assets = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    asset_evaluation = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    destination_place = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    state = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    dependence = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    request_activity = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__loan_com__3213E83FC4D302B9", x => x.id);
                    table.ForeignKey(
                        name: "FK__loan_comp__id_co__02084FDA",
                        column: x => x.id_computer_equipment,
                        principalTable: "computer_equipment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__loan_comp__id_li__03F0984C",
                        column: x => x.id_library_user,
                        principalTable: "library_user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__loan_comp__id_lo__02FC7413",
                        column: x => x.id_loan,
                        principalTable: "loan",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "loan_study_room",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number_of_people = table.Column<int>(type: "int", nullable: true),
                    loan_id = table.Column<int>(type: "int", nullable: true),
                    start_time = table.Column<TimeSpan>(type: "time", nullable: true),
                    end_time = table.Column<TimeSpan>(type: "time", nullable: true),
                    id_user_library = table.Column<int>(type: "int", nullable: true),
                    study_room_id = table.Column<int>(type: "int", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__loan_stu__3213E83F90579D5C", x => x.id);
                    table.ForeignKey(
                        name: "FK__loan_stud__id_us__5535A963",
                        column: x => x.id_user_library,
                        principalTable: "library_user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__loan_stud__loan___5441852A",
                        column: x => x.loan_id,
                        principalTable: "loan",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__loan_stud__study__5629CD9C",
                        column: x => x.study_room_id,
                        principalTable: "study_room",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "return_computer_equipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_library_user = table.Column<int>(type: "int", nullable: true),
                    id_computer_equipment = table.Column<int>(type: "int", nullable: true),
                    delay = table.Column<int>(type: "int", nullable: true),
                    loan_date = table.Column<DateTime>(type: "date", nullable: true),
                    return_date = table.Column<DateTime>(type: "date", nullable: true),
                    limit_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__return_c__3213E83F385230CE", x => x.id);
                    table.ForeignKey(
                        name: "FK__return_co__id_co__07C12930",
                        column: x => x.id_computer_equipment,
                        principalTable: "computer_equipment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__return_co__id_li__06CD04F7",
                        column: x => x.id_library_user,
                        principalTable: "library_user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "sanction_computer_equipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_return_computer_equipment = table.Column<int>(type: "int", nullable: true),
                    sanction_type = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    sanction_expiration = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__sanction__3213E83FC3EA8225", x => x.id);
                    table.ForeignKey(
                        name: "FK__sanction___id_re__0A9D95DB",
                        column: x => x.id_return_computer_equipment,
                        principalTable: "return_computer_equipment",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "sanctions_report",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_library_user = table.Column<int>(type: "int", nullable: true),
                    id_sanction_computer_equipment = table.Column<int>(type: "int", nullable: true),
                    id_return_computer_equipment = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__sanction__3213E83F1D95878F", x => x.id);
                    table.ForeignKey(
                        name: "FK__sanctions__id_li__0D7A0286",
                        column: x => x.id_library_user,
                        principalTable: "library_user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__sanctions__id_re__0F624AF8",
                        column: x => x.id_return_computer_equipment,
                        principalTable: "return_computer_equipment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__sanctions__id_sa__0E6E26BF",
                        column: x => x.id_sanction_computer_equipment,
                        principalTable: "sanction_computer_equipment",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_area_inventory_id",
                table: "area",
                column: "inventory_id");

            migrationBuilder.CreateIndex(
                name: "IX_classroom_schedule_id_classroom",
                table: "classroom_schedule",
                column: "id_classroom");

            migrationBuilder.CreateIndex(
                name: "IX_copy_id_titles",
                table: "copy",
                column: "id_titles");

            migrationBuilder.CreateIndex(
                name: "IX_furniture_id_study_room",
                table: "furniture",
                column: "id_study_room");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_type_inventory_id",
                table: "inventory_type",
                column: "inventory_id");

            migrationBuilder.CreateIndex(
                name: "IX_library_user_id_user",
                table: "library_user",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_loan_book_log_id_loan",
                table: "loan_book_log",
                column: "id_loan");

            migrationBuilder.CreateIndex(
                name: "IX_loan_book_log_id_users",
                table: "loan_book_log",
                column: "id_users");

            migrationBuilder.CreateIndex(
                name: "IX_loan_books_id_copy",
                table: "loan_books",
                column: "id_copy");

            migrationBuilder.CreateIndex(
                name: "IX_loan_books_id_library_user",
                table: "loan_books",
                column: "id_library_user");

            migrationBuilder.CreateIndex(
                name: "IX_loan_books_id_loan",
                table: "loan_books",
                column: "id_loan");

            migrationBuilder.CreateIndex(
                name: "IX_loan_classrooms_id_classroom",
                table: "loan_classrooms",
                column: "id_classroom");

            migrationBuilder.CreateIndex(
                name: "IX_loan_classrooms_id_loan",
                table: "loan_classrooms",
                column: "id_loan");

            migrationBuilder.CreateIndex(
                name: "IX_loan_computer_equipment_id_computer_equipment",
                table: "loan_computer_equipment",
                column: "id_computer_equipment");

            migrationBuilder.CreateIndex(
                name: "IX_loan_computer_equipment_id_library_user",
                table: "loan_computer_equipment",
                column: "id_library_user");

            migrationBuilder.CreateIndex(
                name: "IX_loan_computer_equipment_id_loan",
                table: "loan_computer_equipment",
                column: "id_loan");

            migrationBuilder.CreateIndex(
                name: "IX_loan_field_id_loan",
                table: "loan_field",
                column: "id_loan");

            migrationBuilder.CreateIndex(
                name: "IX_loan_field_id_user",
                table: "loan_field",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_loan_sports_equipment_id_loan",
                table: "loan_sports_equipment",
                column: "id_loan");

            migrationBuilder.CreateIndex(
                name: "IX_loan_sports_equipment_id_user",
                table: "loan_sports_equipment",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_loan_study_room_id_user_library",
                table: "loan_study_room",
                column: "id_user_library");

            migrationBuilder.CreateIndex(
                name: "IX_loan_study_room_loan_id",
                table: "loan_study_room",
                column: "loan_id");

            migrationBuilder.CreateIndex(
                name: "IX_loan_study_room_study_room_id",
                table: "loan_study_room",
                column: "study_room_id");

            migrationBuilder.CreateIndex(
                name: "IX_loan_vehicle_id_loan",
                table: "loan_vehicle",
                column: "id_loan");

            migrationBuilder.CreateIndex(
                name: "IX_loan_vehicle_id_user",
                table: "loan_vehicle",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_report_computer_equipment_id_computer_equipment",
                table: "report_computer_equipment",
                column: "id_computer_equipment");

            migrationBuilder.CreateIndex(
                name: "IX_report_computer_equipment_id_loan_equipment",
                table: "report_computer_equipment",
                column: "id_loan_equipment");

            migrationBuilder.CreateIndex(
                name: "IX_report_computer_equipment_id_return_equipment",
                table: "report_computer_equipment",
                column: "id_return_equipment");

            migrationBuilder.CreateIndex(
                name: "IX_return_computer_equipment_id_computer_equipment",
                table: "return_computer_equipment",
                column: "id_computer_equipment");

            migrationBuilder.CreateIndex(
                name: "IX_return_computer_equipment_id_library_user",
                table: "return_computer_equipment",
                column: "id_library_user");

            migrationBuilder.CreateIndex(
                name: "IX_role_privileges_privileges_id",
                table: "role_privileges",
                column: "privileges_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_privileges_role_id",
                table: "role_privileges",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_sanction_computer_equipment_id_return_computer_equipment",
                table: "sanction_computer_equipment",
                column: "id_return_computer_equipment");

            migrationBuilder.CreateIndex(
                name: "IX_sanctions_report_id_library_user",
                table: "sanctions_report",
                column: "id_library_user");

            migrationBuilder.CreateIndex(
                name: "IX_sanctions_report_id_return_computer_equipment",
                table: "sanctions_report",
                column: "id_return_computer_equipment");

            migrationBuilder.CreateIndex(
                name: "IX_sanctions_report_id_sanction_computer_equipment",
                table: "sanctions_report",
                column: "id_sanction_computer_equipment");

            migrationBuilder.CreateIndex(
                name: "IX_study_room_schedule_id_study_room",
                table: "study_room_schedule",
                column: "id_study_room");

            migrationBuilder.CreateIndex(
                name: "IX_userr_role_id",
                table: "userr",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "area");

            migrationBuilder.DropTable(
                name: "classroom_schedule");

            migrationBuilder.DropTable(
                name: "furniture");

            migrationBuilder.DropTable(
                name: "inventory_type");

            migrationBuilder.DropTable(
                name: "loan_book_log");

            migrationBuilder.DropTable(
                name: "loan_books");

            migrationBuilder.DropTable(
                name: "loan_classrooms");

            migrationBuilder.DropTable(
                name: "loan_computer_equipment");

            migrationBuilder.DropTable(
                name: "loan_field");

            migrationBuilder.DropTable(
                name: "loan_sports_equipment");

            migrationBuilder.DropTable(
                name: "loan_study_room");

            migrationBuilder.DropTable(
                name: "loan_vehicle");

            migrationBuilder.DropTable(
                name: "report_computer_equipment");

            migrationBuilder.DropTable(
                name: "role_privileges");

            migrationBuilder.DropTable(
                name: "sanctions_report");

            migrationBuilder.DropTable(
                name: "study_room_schedule");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "copy");

            migrationBuilder.DropTable(
                name: "classrooms");

            migrationBuilder.DropTable(
                name: "loan");

            migrationBuilder.DropTable(
                name: "privileges");

            migrationBuilder.DropTable(
                name: "sanction_computer_equipment");

            migrationBuilder.DropTable(
                name: "study_room");

            migrationBuilder.DropTable(
                name: "titles");

            migrationBuilder.DropTable(
                name: "return_computer_equipment");

            migrationBuilder.DropTable(
                name: "computer_equipment");

            migrationBuilder.DropTable(
                name: "library_user");

            migrationBuilder.DropTable(
                name: "userr");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
