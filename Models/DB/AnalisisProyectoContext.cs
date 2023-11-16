using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AnalisisProyecto.Models.DB;

public partial class AnalisisProyectoContext : DbContext {
    public AnalisisProyectoContext() {
    }

    public AnalisisProyectoContext(DbContextOptions<AnalisisProyectoContext> options)
        : base(options) {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<ClassroomSchedule> ClassroomSchedules { get; set; }

    public virtual DbSet<ComputerEquipment> ComputerEquipments { get; set; }

    public virtual DbSet<Copy> Copies { get; set; }

    public virtual DbSet<Furniture> Furnitures { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<InventoryType> InventoryTypes { get; set; }

    public virtual DbSet<LibraryUser> LibraryUsers { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<LoanBook> LoanBooks { get; set; }

    public virtual DbSet<LoanBookLog> LoanBookLogs { get; set; }

    public virtual DbSet<LoanClassroom> LoanClassrooms { get; set; }

    public virtual DbSet<LoanComputerEquipment> LoanComputerEquipments { get; set; }

    public virtual DbSet<LoanField> LoanFields { get; set; }

    public virtual DbSet<LoanSportsEquipment> LoanSportsEquipments { get; set; }

    public virtual DbSet<LoanStudyRoom> LoanStudyRooms { get; set; }

    public virtual DbSet<LoanVehicle> LoanVehicles { get; set; }

    public virtual DbSet<Privilege> Privileges { get; set; }

    public virtual DbSet<ReportComputerEquipment> ReportComputerEquipments { get; set; }

    public virtual DbSet<ReturnComputerEquipment> ReturnComputerEquipments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePrivilege> RolePrivileges { get; set; }

    public virtual DbSet<SanctionComputerEquipment> SanctionComputerEquipments { get; set; }

    public virtual DbSet<SanctionsReport> SanctionsReports { get; set; }

    public virtual DbSet<StudyRoom> StudyRooms { get; set; }

    public virtual DbSet<StudyRoomSchedule> StudyRoomSchedules { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    public virtual DbSet<Userr> Userrs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AnalisisProyecto.mssql.somee.com; Database=AnalisisProyecto; User Id=jeykel_SQLLogin_4; Password=yp7hqe6tb5; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Area>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__area__3213E83F204CAC68");

            entity.ToTable("area");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Area1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("area");
            entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

            entity.HasOne(d => d.Inventory).WithMany(p => p.Areas)
                .HasForeignKey(d => d.InventoryId)
                .HasConstraintName("FK__area__inventory___5165187F");
        });

        modelBuilder.Entity<Classroom>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__classroo__3213E83F5D82BCDE");

            entity.ToTable("classrooms");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Numeration)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("numeration");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Requirements)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("requirements");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<ClassroomSchedule>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__classroo__3213E83FA5364179");

            entity.ToTable("classroom_schedule");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Day)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("day");
            entity.Property(e => e.EndHour).HasColumnName("end_hour");
            entity.Property(e => e.IdClassroom).HasColumnName("id_classroom");
            entity.Property(e => e.StartHour).HasColumnName("start_hour");

            entity.HasOne(d => d.IdClassroomNavigation).WithMany(p => p.ClassroomSchedules)
                .HasForeignKey(d => d.IdClassroom)
                .HasConstraintName("FK__classroom__id_cl__6B24EA82");
        });

        modelBuilder.Entity<ComputerEquipment>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__computer__3213E83F8B66061B");

            entity.ToTable("computer_equipment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("brand");
            entity.Property(e => e.Class)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("class");
            entity.Property(e => e.EntryDate)
                .HasColumnType("date")
                .HasColumnName("entry_date");
            entity.Property(e => e.Include)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("include");
            entity.Property(e => e.LastModifications)
                .HasColumnType("date")
                .HasColumnName("last_modifications");
            entity.Property(e => e.LicensePlate)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("license_plate");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("model");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Observations)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("observations");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("serial_number");
            entity.Property(e => e.State)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("state");
        });

        modelBuilder.Entity<Copy>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__copy__3213E83F154913F7");

            entity.ToTable("copy");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Barcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("barcode");
            entity.Property(e => e.Classification)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("classification");
            entity.Property(e => e.Collection)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("collection");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IdTitles).HasColumnName("id_titles");
            entity.Property(e => e.ItemStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("item_status");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("notes");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.SubLibrary)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sub_library");

            entity.HasOne(d => d.IdTitlesNavigation).WithMany(p => p.Copies)
                .HasForeignKey(d => d.IdTitles)
                .HasConstraintName("FK__copy__id_titles__628FA481");
        });

        modelBuilder.Entity<Furniture>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__furnitur__3213E83F43831C07");

            entity.ToTable("furniture");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.furniture)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("furniture");
            entity.Property(e => e.id_study_room).HasColumnName("id_study_room");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Capacity).HasColumnName("capacity");


            entity.HasOne(d => d.IdStudyRoomNavigation).WithMany(p => p.Furnitures)
                .HasForeignKey(d => d.id_study_room)
                .HasConstraintName("FK__furniture__furni__59063A47");
        });

        modelBuilder.Entity<Inventory>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__inventor__3213E83F34C54636");

            entity.ToTable("inventory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Units).HasColumnName("units");
        });

        modelBuilder.Entity<InventoryType>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__inventor__3213E83FCC7DC832");

            entity.ToTable("inventory_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.InventoryId).HasColumnName("inventory_id");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.Inventory).WithMany(p => p.InventoryTypes)
                .HasForeignKey(d => d.InventoryId)
                .HasConstraintName("FK__inventory__inven__4E88ABD4");
        });

        modelBuilder.Entity<LibraryUser>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__library___3213E83F8A2693CE");

            entity.ToTable("library_user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Library)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("library");
            entity.Property(e => e.Privilege)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("privilege");
            entity.Property(e => e.TypeUser)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type_user");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.LibraryUsers)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__library_u__id_us__4BAC3F29");
        });

        modelBuilder.Entity<Loan>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__loan__3213E83F893123D6");

            entity.ToTable("loan");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.RegisterDate)
                .HasColumnType("date")
                .HasColumnName("register_date");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
        });

        modelBuilder.Entity<LoanBook>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__loan_boo__3213E83FAF530B67");

            entity.ToTable("loan_books");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCopy).HasColumnName("id_copy");
            entity.Property(e => e.IdLibraryUser).HasColumnName("id_library_user");
            entity.Property(e => e.IdLoan).HasColumnName("id_loan");
            entity.Property(e => e.LimitFines)
                .HasColumnType("date")
                .HasColumnName("limit_fines");
            entity.Property(e => e.Observation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("observation");
            entity.Property(e => e.PhotocopyCharge)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("photocopy_charge");
            entity.Property(e => e.SubLibrary)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sub_library");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.IdCopyNavigation).WithMany(p => p.LoanBooks)
                .HasForeignKey(d => d.IdCopy)
                .HasConstraintName("FK__loan_book__id_co__6EF57B66");

            entity.HasOne(d => d.IdLibraryUserNavigation).WithMany(p => p.LoanBooks)
                .HasForeignKey(d => d.IdLibraryUser)
                .HasConstraintName("FK__loan_book__id_li__6FE99F9F");

            entity.HasOne(d => d.IdLoanNavigation).WithMany(p => p.LoanBooks)
                .HasForeignKey(d => d.IdLoan)
                .HasConstraintName("FK__loan_book__id_lo__6E01572D");
        });

        modelBuilder.Entity<LoanBookLog>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__loan_boo__3213E83F2ED945BD");

            entity.ToTable("loan_book_log");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Barcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("barcode");
            entity.Property(e => e.BibliographicInformation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("bibliographic_information");
            entity.Property(e => e.ExpirationDate)
                .HasColumnType("date")
                .HasColumnName("expiration_date");
            entity.Property(e => e.Hour).HasColumnName("hour");
            entity.Property(e => e.IdLoan).HasColumnName("id_loan");
            entity.Property(e => e.IdUsers).HasColumnName("id_users");
            entity.Property(e => e.Penalty)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("penalty");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.SubLibrary)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sub_library");

            entity.HasOne(d => d.IdLoanNavigation).WithMany(p => p.LoanBookLogs)
                .HasForeignKey(d => d.IdLoan)
                .HasConstraintName("FK__loan_book__id_lo__5FB337D6");

            entity.HasOne(d => d.IdUsersNavigation).WithMany(p => p.LoanBookLogs)
                .HasForeignKey(d => d.IdUsers)
                .HasConstraintName("FK__loan_book__id_us__5EBF139D");
        });

        modelBuilder.Entity<LoanClassroom>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__loan_cla__3213E83F1C9FA5E6");

            entity.ToTable("loan_classrooms");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdClassroom).HasColumnName("id_classroom");
            entity.Property(e => e.IdLoan).HasColumnName("id_loan");
            entity.Property(e => e.PersonQuantity).HasColumnName("person_quantity");

            entity.HasOne(d => d.IdClassroomNavigation).WithMany(p => p.LoanClassrooms)
                .HasForeignKey(d => d.IdClassroom)
                .HasConstraintName("FK__loan_clas__id_cl__7B5B524B");

            entity.HasOne(d => d.IdLoanNavigation).WithMany(p => p.LoanClassrooms)
                .HasForeignKey(d => d.IdLoan)
                .HasConstraintName("FK__loan_clas__id_lo__7A672E12");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.LoanClassrooms)
            .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__loan_clas__id_us__7C4F7684");
        });

        modelBuilder.Entity<LoanComputerEquipment>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__loan_com__3213E83FC4D302B9");

            entity.ToTable("loan_computer_equipment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssetEvaluation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("asset_evaluation");
            entity.Property(e => e.Assets)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("assets");
            entity.Property(e => e.Dependence)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("dependence");
            entity.Property(e => e.DestinationPlace)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("destination_place");
            entity.Property(e => e.IdComputerEquipment).HasColumnName("id_computer_equipment");
            entity.Property(e => e.IdLibraryUser).HasColumnName("id_library_user");
            entity.Property(e => e.IdLoan).HasColumnName("id_loan");
            entity.Property(e => e.RequestActivity)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("request_activity");
            entity.Property(e => e.State)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("state");

            entity.HasOne(d => d.IdComputerEquipmentNavigation).WithMany(p => p.LoanComputerEquipments)
                .HasForeignKey(d => d.IdComputerEquipment)
                .HasConstraintName("FK__loan_comp__id_co__02084FDA");

            entity.HasOne(d => d.IdLibraryUserNavigation).WithMany(p => p.LoanComputerEquipments)
                .HasForeignKey(d => d.IdLibraryUser)
                .HasConstraintName("FK__loan_comp__id_li__03F0984C");

            entity.HasOne(d => d.IdLoanNavigation).WithMany(p => p.LoanComputerEquipments)
                .HasForeignKey(d => d.IdLoan)
                .HasConstraintName("FK__loan_comp__id_lo__02FC7413");
        });

        modelBuilder.Entity<LoanField>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__loan_fie__3213E83F288E3255");

            entity.ToTable("loan_field");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdLoan).HasColumnName("id_loan");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Lightning).HasColumnName("lightning");
            entity.Property(e => e.Materials)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("materials");

            entity.HasOne(d => d.IdLoanNavigation).WithMany(p => p.LoanFields)
                .HasForeignKey(d => d.IdLoan)
                .HasConstraintName("FK__loan_fiel__id_lo__72C60C4A");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.LoanFields)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__loan_fiel__id_us__73BA3083");
        });

        modelBuilder.Entity<LoanSportsEquipment>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__loan_spo__3213E83FEE7317A0");

            entity.ToTable("loan_sports_equipment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdLoan).HasColumnName("id_loan");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Materials)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("materials");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdLoanNavigation).WithMany(p => p.LoanSportsEquipments)
                .HasForeignKey(d => d.IdLoan)
                .HasConstraintName("FK__loan_spor__id_lo__76969D2E");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.LoanSportsEquipments)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__loan_spor__id_us__778AC167");
        });

        modelBuilder.Entity<LoanStudyRoom>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__loan_stu__3213E83F90579D5C");

            entity.ToTable("loan_study_room");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.IdUserLibrary).HasColumnName("id_user_library");
            entity.Property(e => e.LoanId).HasColumnName("loan_id");
            entity.Property(e => e.NumberOfPeople).HasColumnName("number_of_people");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.StudyRoomId).HasColumnName("study_room_id");

            entity.HasOne(d => d.IdUserLibraryNavigation).WithMany(p => p.LoanStudyRooms)
                .HasForeignKey(d => d.IdUserLibrary)
                .HasConstraintName("FK__loan_stud__id_us__5535A963");

            entity.HasOne(d => d.Loan).WithMany(p => p.LoanStudyRooms)
                .HasForeignKey(d => d.LoanId)
                .HasConstraintName("FK__loan_stud__loan___5441852A");

            entity.HasOne(d => d.StudyRoom).WithMany(p => p.LoanStudyRooms)
                .HasForeignKey(d => d.StudyRoomId)
                .HasConstraintName("FK__loan_stud__study__5629CD9C");
            entity.Property(e => e.Active).HasColumnName("active");
        });

        modelBuilder.Entity<LoanVehicle>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__loan_veh__3213E83F5C45B1D1");

            entity.ToTable("loan_vehicle");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivityType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("activity_type");
            entity.Property(e => e.AssignedVehicle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("assigned_vehicle");
            entity.Property(e => e.Destination)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("destination");
            entity.Property(e => e.ExitDate)
                .HasColumnType("date")
                .HasColumnName("exit_date");
            entity.Property(e => e.ExitHour).HasColumnName("exit_hour");
            entity.Property(e => e.IdLoan).HasColumnName("id_loan");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.PersonQuantity).HasColumnName("person_quantity");
            entity.Property(e => e.RegisterDate)
                .HasColumnType("date")
                .HasColumnName("register_date");
            entity.Property(e => e.Responsible)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("responsible");
            entity.Property(e => e.ReturnDate)
                .HasColumnType("date")
                .HasColumnName("return_date");
            entity.Property(e => e.ReturnHour).HasColumnName("return_hour");
            entity.Property(e => e.StartingPlace)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("starting_place");
            entity.Property(e => e.State)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.UnityOrCarrer)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("unity_or_carrer");

            entity.HasOne(d => d.IdLoanNavigation).WithMany(p => p.LoanVehicles)
                .HasForeignKey(d => d.IdLoan)
                .HasConstraintName("FK__loan_vehi__id_lo__7E37BEF6");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.LoanVehicles)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__loan_vehi__id_us__7F2BE32F");
            entity.Property(e => e.Active).HasColumnName("active");
        });

        modelBuilder.Entity<Privilege>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__privileg__3213E83F2DBC5980");

            entity.ToTable("privileges");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<ReportComputerEquipment>(entity => {
            entity
                .HasNoKey()
                .ToTable("report_computer_equipment");

            entity.Property(e => e.IdComputerEquipment).HasColumnName("id_computer_equipment");
            entity.Property(e => e.IdLoanEquipment).HasColumnName("id_loan_equipment");
            entity.Property(e => e.IdReturnEquipment).HasColumnName("id_return_equipment");

            entity.HasOne(d => d.IdComputerEquipmentNavigation).WithMany()
                .HasForeignKey(d => d.IdComputerEquipment)
                .HasConstraintName("FK__report_co__id_co__6477ECF3");

            entity.HasOne(d => d.IdLoanEquipmentNavigation).WithMany()
                .HasForeignKey(d => d.IdLoanEquipment)
                .HasConstraintName("FK__report_co__id_lo__66603565");

            entity.HasOne(d => d.IdReturnEquipmentNavigation).WithMany()
                .HasForeignKey(d => d.IdReturnEquipment)
                .HasConstraintName("FK__report_co__id_re__656C112C");
        });

        modelBuilder.Entity<ReturnComputerEquipment>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__return_c__3213E83F385230CE");

            entity.ToTable("return_computer_equipment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Delay).HasColumnName("delay");
            entity.Property(e => e.IdComputerEquipment).HasColumnName("id_computer_equipment");
            entity.Property(e => e.IdLibraryUser).HasColumnName("id_library_user");
            entity.Property(e => e.LimitDate)
                .HasColumnType("date")
                .HasColumnName("limit_date");
            entity.Property(e => e.LoanDate)
                .HasColumnType("date")
                .HasColumnName("loan_date");
            entity.Property(e => e.ReturnDate)
                .HasColumnType("date")
                .HasColumnName("return_date");

            entity.HasOne(d => d.IdComputerEquipmentNavigation).WithMany(p => p.ReturnComputerEquipments)
                .HasForeignKey(d => d.IdComputerEquipment)
                .HasConstraintName("FK__return_co__id_co__07C12930");

            entity.HasOne(d => d.IdLibraryUserNavigation).WithMany(p => p.ReturnComputerEquipments)
                .HasForeignKey(d => d.IdLibraryUser)
                .HasConstraintName("FK__return_co__id_li__06CD04F7");
        });

        modelBuilder.Entity<Role>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__role__3213E83F87D9164D");

            entity.ToTable("role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<RolePrivilege>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__role_pri__3213E83F3B5BF317");

            entity.ToTable("role_privileges");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PrivilegesId).HasColumnName("privileges_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Privileges).WithMany(p => p.RolePrivileges)
                .HasForeignKey(d => d.PrivilegesId)
                .HasConstraintName("FK__role_priv__privi__3F466844");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePrivileges)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__role_priv__role___3E52440B");
        });

        modelBuilder.Entity<SanctionComputerEquipment>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__sanction__3213E83FC3EA8225");

            entity.ToTable("sanction_computer_equipment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.IdReturnComputerEquipment).HasColumnName("id_return_computer_equipment");
            entity.Property(e => e.SanctionExpiration)
                .HasColumnType("date")
                .HasColumnName("sanction_expiration");
            entity.Property(e => e.SanctionType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sanction_type");

            entity.HasOne(d => d.IdReturnComputerEquipmentNavigation).WithMany(p => p.SanctionComputerEquipments)
                .HasForeignKey(d => d.IdReturnComputerEquipment)
                .HasConstraintName("FK__sanction___id_re__0A9D95DB");
        });

        modelBuilder.Entity<SanctionsReport>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__sanction__3213E83F1D95878F");

            entity.ToTable("sanctions_report");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdLibraryUser).HasColumnName("id_library_user");
            entity.Property(e => e.IdReturnComputerEquipment).HasColumnName("id_return_computer_equipment");
            entity.Property(e => e.IdSanctionComputerEquipment).HasColumnName("id_sanction_computer_equipment");

            entity.HasOne(d => d.IdLibraryUserNavigation).WithMany(p => p.SanctionsReports)
                .HasForeignKey(d => d.IdLibraryUser)
                .HasConstraintName("FK__sanctions__id_li__0D7A0286");

            entity.HasOne(d => d.IdReturnComputerEquipmentNavigation).WithMany(p => p.SanctionsReports)
                .HasForeignKey(d => d.IdReturnComputerEquipment)
                .HasConstraintName("FK__sanctions__id_re__0F624AF8");

            entity.HasOne(d => d.IdSanctionComputerEquipmentNavigation).WithMany(p => p.SanctionsReports)
                .HasForeignKey(d => d.IdSanctionComputerEquipment)
                .HasConstraintName("FK__sanctions__id_sa__0E6E26BF");
        });

        modelBuilder.Entity<StudyRoom>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__study_ro__3213E83FFC182EAC");

            entity.ToTable("study_room");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.IsAvailable).HasColumnName("isAvailable");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Active).HasColumnName("active");
        });

        modelBuilder.Entity<StudyRoomSchedule>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__study_ro__3213E83F701452AA");

            entity.ToTable("study_room_schedule");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Day)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("day");
            entity.Property(e => e.EndHour).HasMaxLength(5).HasColumnName("end_hour");
            entity.Property(e => e.IdStudyRoom).HasColumnName("id_study_room");
            entity.Property(e => e.StartHour).HasMaxLength(5).HasColumnName("start_hour");

           entity.HasOne(d => d.IdStudyRoomNavigation).WithMany(p => p.StudyRoomSchedules)
                .HasForeignKey(d => d.IdStudyRoom)
                .HasConstraintName("FK__study_roo__id_st__5BE2A6F2");
            entity.Property(e => e.Active).HasColumnName("active");

        });
       

        modelBuilder.Entity<Title>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__titles__3213E83F1E7D6FF8");

            entity.ToTable("titles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssociatedDate)
                .HasColumnType("date")
                .HasColumnName("associated_date");
            entity.Property(e => e.GeneralSubjectSubdivision)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("general_subject_subdivision");
            entity.Property(e => e.Header)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("header");
            entity.Property(e => e.Information)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("information");
            entity.Property(e => e.Isbn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.MentionResponsibility)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mention_responsibility");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.PersonName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("person_name");
            entity.Property(e => e.PublicationDate)
                .HasColumnType("date")
                .HasColumnName("publication_date");
            entity.Property(e => e.PublisherName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("publisher_name");
            entity.Property(e => e.RestTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("rest_title");
            entity.Property(e => e.TermSubject)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("term_subject");
            entity.Property(e => e.Title1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Userr>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__userr__3213E83F87C1CAD7");

            entity.ToTable("userr");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Career)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("career");
            entity.Property(e => e.Category)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.CreationDate)
                .HasColumnType("date")
                .HasColumnName("creation_date");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Userrs)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__userr__role_id__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
