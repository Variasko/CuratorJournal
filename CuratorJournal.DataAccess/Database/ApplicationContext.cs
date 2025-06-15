using System;
using System.Collections.Generic;
using CuratorJournal.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CuratorJournal.DataAccess.Database;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClassHour> ClassHours { get; set; }

    public virtual DbSet<Curator> Curators { get; set; }

    public virtual DbSet<CuratorCharacteristic> CuratorCharacteristics { get; set; }

    public virtual DbSet<GroupPost> GroupPosts { get; set; }

    public virtual DbSet<Hobby> Hobbies { get; set; }

    public virtual DbSet<IndividualWork> IndividualWorks { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<ParentMeeting> ParentMeetings { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Qualification> Qualifications { get; set; }

    public virtual DbSet<SocialStatus> SocialStatuses { get; set; }

    public virtual DbSet<Specification> Specifications { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentClassHour> StudentClassHours { get; set; }

    public virtual DbSet<StudentInDormitory> StudentInDormitories { get; set; }

    public virtual DbSet<StudyGroup> StudyGroups { get; set; }

    public virtual DbSet<TeacherCategory> TeacherCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-J7F367J\\SQLEXPRESS01;Database=CuratorJournal;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClassHour>(entity =>
        {
            entity.HasKey(e => e.ClassHourId).HasName("PK__ClassHou__C486626AE8AAE772");

            entity.ToTable("ClassHour");

            entity.Property(e => e.Decision).HasColumnType("text");
            entity.Property(e => e.Topic).HasColumnType("text");
        });

        modelBuilder.Entity<Curator>(entity =>
        {
            entity.HasKey(e => e.CuratorId).HasName("PK__Curator__FC8BDC5A180388CF");

            entity.ToTable("Curator");

            entity.HasOne(d => d.Category).WithMany(p => p.Curators)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Curator__Categor__5535A963");

            entity.HasOne(d => d.Person).WithMany(p => p.Curators)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Curator__PersonI__5629CD9C");

            entity.HasOne(d => d.User).WithMany(p => p.Curators)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Curator__UserId__571DF1D5");

            entity.HasMany(d => d.StudyGroups).WithMany(p => p.Curators)
                .UsingEntity<Dictionary<string, object>>(
                    "CuratorStudyGroup",
                    r => r.HasOne<StudyGroup>().WithMany()
                        .HasForeignKey("StudyGroupId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CuratorSt__Study__5AEE82B9"),
                    l => l.HasOne<Curator>().WithMany()
                        .HasForeignKey("CuratorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CuratorSt__Curat__59FA5E80"),
                    j =>
                    {
                        j.HasKey("CuratorId", "StudyGroupId");
                        j.ToTable("CuratorStudyGroup");
                    });
        });

        modelBuilder.Entity<CuratorCharacteristic>(entity =>
        {
            entity.HasKey(e => e.CharacteristicId).HasName("PK__CuratorC__C0EA4DCFC5CCDA32");

            entity.ToTable("CuratorCharacteristic");

            entity.Property(e => e.Characteristic).HasColumnType("text");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Curator).WithMany(p => p.CuratorCharacteristics)
                .HasForeignKey(d => d.CuratorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CuratorCh__Curat__5812160E");

            entity.HasOne(d => d.Student).WithMany(p => p.CuratorCharacteristics)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CuratorCh__Stude__59063A47");
        });

        modelBuilder.Entity<GroupPost>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__GroupPos__AA126018E843644C");

            entity.ToTable("GroupPost");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Hobby>(entity =>
        {
            entity.HasKey(e => e.HobbyId).HasName("PK__Hobby__0ABE0BCF15601C82");

            entity.ToTable("Hobby");

            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<IndividualWork>(entity =>
        {
            entity.HasKey(e => e.IndividualWorkId).HasName("PK__Individu__EBE77C1837D56D6B");

            entity.ToTable("IndividualWork");

            entity.Property(e => e.Decision).HasColumnType("text");
            entity.Property(e => e.IsStudent).HasDefaultValue(true);
            entity.Property(e => e.Topic).HasColumnType("text");

            entity.HasOne(d => d.Parent).WithMany(p => p.IndividualWorks)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__Individua__Paren__5CD6CB2B");

            entity.HasOne(d => d.Student).WithMany(p => p.IndividualWorks)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Individua__Stude__5BE2A6F2");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.ParentId).HasName("PK__Parent__D339516F68E45902");

            entity.ToTable("Parent");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(12);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasMany(d => d.Students).WithMany(p => p.Parents)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentParent",
                    r => r.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentPa__Stude__656C112C"),
                    l => l.HasOne<Parent>().WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentPa__Paren__6477ECF3"),
                    j =>
                    {
                        j.HasKey("ParentId", "StudentId");
                        j.ToTable("StudentParent");
                    });
        });

        modelBuilder.Entity<ParentMeeting>(entity =>
        {
            entity.HasKey(e => e.MeetingId).HasName("PK__ParentMe__E9F9E94C039897F2");

            entity.ToTable("ParentMeeting");

            entity.Property(e => e.Decision).HasColumnType("text");
            entity.Property(e => e.Topic).HasColumnType("text");

            entity.HasOne(d => d.StudyGroup).WithMany(p => p.ParentMeetings)
                .HasForeignKey(d => d.StudyGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ParentMee__Study__5DCAEF64");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Person__AA2FFBE5091476C2");

            entity.ToTable("Person");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Inn)
                .HasMaxLength(12)
                .HasColumnName("INN");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PassportNumber).HasMaxLength(6);
            entity.Property(e => e.PassportSerial).HasMaxLength(4);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(12);
            entity.Property(e => e.Snils)
                .HasMaxLength(11)
                .HasColumnName("SNILS");
            entity.Property(e => e.Surname).HasMaxLength(50);
            entity.Property(e => e.WhoGavePassport).HasMaxLength(50);
        });

        modelBuilder.Entity<Qualification>(entity =>
        {
            entity.HasKey(e => e.Abbreviation).HasName("PK__Speciali__9C41170F89866CA3");

            entity.ToTable("Qualification");

            entity.Property(e => e.Abbreviation).HasMaxLength(3);
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<SocialStatus>(entity =>
        {
            entity.HasKey(e => e.SocialStatusId).HasName("PK__SocialSt__B2D12E6B5E39FAF9");

            entity.ToTable("SocialStatus");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasMany(d => d.Students).WithMany(p => p.SocialStatuses)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentSocialStatus",
                    r => r.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentSo__Stude__66603565"),
                    l => l.HasOne<SocialStatus>().WithMany()
                        .HasForeignKey("SocialStatusId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentSo__Socia__6754599E"),
                    j =>
                    {
                        j.HasKey("SocialStatusId", "StudentId");
                        j.ToTable("StudentSocialStatus");
                    });
        });

        modelBuilder.Entity<Specification>(entity =>
        {
            entity.HasKey(e => e.Abbreviation).HasName("PK__Directio__9C41170FDB2E6D3D");

            entity.ToTable("Specification");

            entity.Property(e => e.Abbreviation).HasMaxLength(3);
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B9950AF0A31");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId).ValueGeneratedNever();

            entity.HasOne(d => d.StudentNavigation).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student__Student__5EBF139D");

            entity.HasMany(d => d.Hobbies).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentHobby",
                    r => r.HasOne<Hobby>().WithMany()
                        .HasForeignKey("HobbyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentHo__Hobby__628FA481"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentHo__Stude__619B8048"),
                    j =>
                    {
                        j.HasKey("StudentId", "HobbyId");
                        j.ToTable("StudentHobby");
                    });

            entity.HasMany(d => d.Posts).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudyGroupPost",
                    r => r.HasOne<GroupPost>().WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudyGrou__PostI__6D0D32F4"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudyGrou__Stude__6C190EBB"),
                    j =>
                    {
                        j.HasKey("StudentId", "PostId");
                        j.ToTable("StudyGroupPost");
                    });

            entity.HasMany(d => d.StudyGroups).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentStudyGroup",
                    r => r.HasOne<StudyGroup>().WithMany()
                        .HasForeignKey("StudyGroupId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentSt__Study__693CA210"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentSt__Stude__68487DD7"),
                    j =>
                    {
                        j.HasKey("StudentId", "StudyGroupId");
                        j.ToTable("StudentStudyGroup");
                    });
        });

        modelBuilder.Entity<StudentClassHour>(entity =>
        {
            entity.HasKey(e => new { e.ClassHourId, e.StudentId });

            entity.ToTable("StudentClassHour");

            entity.HasOne(d => d.ClassHour).WithMany(p => p.StudentClassHours)
                .HasForeignKey(d => d.ClassHourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentCl__Class__5FB337D6");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentClassHours)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentCl__Stude__60A75C0F");
        });

        modelBuilder.Entity<StudentInDormitory>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.Room });

            entity.ToTable("StudentInDormitory");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentInDormitories)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentIn__Stude__6383C8BA");
        });

        modelBuilder.Entity<StudyGroup>(entity =>
        {
            entity.HasKey(e => e.StudyGroupId).HasName("PK__StudyGro__D97A1BE27006F813");

            entity.ToTable("StudyGroup");

            entity.Property(e => e.FullName)
                .HasMaxLength(10)
                .HasComputedColumnSql("(((([SpecificationAbbreviation]+'-')+CONVERT([char](1),[Course]))+right(CONVERT([varchar],datepart(year,[DateCreate])),(2)))+isnull([QualificationAbbreviation],''))", false);
            entity.Property(e => e.IsBuget).HasDefaultValue(true);
            entity.Property(e => e.QualificationAbbreviation).HasMaxLength(3);
            entity.Property(e => e.SpecificationAbbreviation).HasMaxLength(3);

            entity.HasOne(d => d.QualificationAbbreviationNavigation).WithMany(p => p.StudyGroups)
                .HasForeignKey(d => d.QualificationAbbreviation)
                .HasConstraintName("FK__StudyGrou__Quali__6B24EA82");

            entity.HasOne(d => d.SpecificationAbbreviationNavigation).WithMany(p => p.StudyGroups)
                .HasForeignKey(d => d.SpecificationAbbreviation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudyGrou__Speci__6A30C649");
        });

        modelBuilder.Entity<TeacherCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__TeacherC__19093A0B939241AE");

            entity.ToTable("TeacherCategory");

            entity.Property(e => e.Name).HasMaxLength(33);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C561EBA39");

            entity.ToTable("User");

            entity.Property(e => e.Login).HasMaxLength(30);
            entity.Property(e => e.Password).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
