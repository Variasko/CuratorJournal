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

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<GroupPost> GroupPosts { get; set; }

    public virtual DbSet<Hobby> Hobbies { get; set; }

    public virtual DbSet<IndividualWork> IndividualWorks { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<ParentMeeting> ParentMeetings { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<SocialStatus> SocialStatuses { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentClassHour> StudentClassHours { get; set; }

    public virtual DbSet<StudentInDormitory> StudentInDormitories { get; set; }

    public virtual DbSet<StudyGroup> StudyGroups { get; set; }

    public virtual DbSet<TeacherCategory> TeacherCategories { get; set; }

    public virtual DbSet<Translation> Translations { get; set; }

    public virtual DbSet<TranslationKey> TranslationKeys { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-J7F367J\\SQLEXPRESS;Database=CuratorJournal;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClassHour>(entity =>
        {
            entity.HasKey(e => e.ClassHourId).HasName("PK__ClassHou__C486626A6DEBF0A2");

            entity.ToTable("ClassHour");

            entity.Property(e => e.Decision).HasColumnType("text");
            entity.Property(e => e.Topic).HasColumnType("text");
        });

        modelBuilder.Entity<Curator>(entity =>
        {
            entity.HasKey(e => e.CuratorId).HasName("PK__Curator__FC8BDC5A3A0050D3");

            entity.ToTable("Curator");

            entity.Property(e => e.CuratorId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Category).WithMany(p => p.Curators)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Curator__Categor__2C3393D0");

            entity.HasOne(d => d.CuratorNavigation).WithOne(p => p.Curator)
                .HasForeignKey<Curator>(d => d.CuratorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Curator_Person");

            entity.HasMany(d => d.StudyGroups).WithMany(p => p.Curators)
                .UsingEntity<Dictionary<string, object>>(
                    "CuratorStudyGroup",
                    r => r.HasOne<StudyGroup>().WithMany()
                        .HasForeignKey("StudyGroupId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CuratorSt__Study__3E52440B"),
                    l => l.HasOne<Curator>().WithMany()
                        .HasForeignKey("CuratorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CuratorSt__Curat__3D5E1FD2"),
                    j =>
                    {
                        j.HasKey("CuratorId", "StudyGroupId");
                        j.ToTable("CuratorStudyGroup");
                    });
        });

        modelBuilder.Entity<CuratorCharacteristic>(entity =>
        {
            entity.HasKey(e => e.CharacteristicId).HasName("PK__CuratorC__C0EA4DCF956279D8");

            entity.ToTable("CuratorCharacteristic");

            entity.Property(e => e.Characteristic).HasColumnType("text");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Curator).WithMany(p => p.CuratorCharacteristics)
                .HasForeignKey(d => d.CuratorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CuratorCh__Curat__4CA06362");

            entity.HasOne(d => d.Student).WithMany(p => p.CuratorCharacteristics)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CuratorCh__Stude__4BAC3F29");
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.HasKey(e => e.Abbreviation).HasName("PK__Directio__9C41170FAD52180A");

            entity.ToTable("Direction");

            entity.Property(e => e.Abbreviation).HasMaxLength(3);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<GroupPost>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__GroupPos__AA126018CDEB261C");

            entity.ToTable("GroupPost");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Hobby>(entity =>
        {
            entity.HasKey(e => e.HobbyId).HasName("PK__Hobby__0ABE0BCF6D09222A");

            entity.ToTable("Hobby");

            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<IndividualWork>(entity =>
        {
            entity.HasKey(e => e.IndividualWorkId).HasName("PK__Individu__EBE77C180FA688ED");

            entity.ToTable("IndividualWork");

            entity.Property(e => e.Decision).HasColumnType("text");
            entity.Property(e => e.IsStudent).HasDefaultValue(true);
            entity.Property(e => e.Topic).HasColumnType("text");

            entity.HasOne(d => d.Parent).WithMany(p => p.IndividualWorks)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__Individua__Paren__6EF57B66");

            entity.HasOne(d => d.Student).WithMany(p => p.IndividualWorks)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Individua__Stude__6E01572D");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("Language");

            entity.Property(e => e.Code)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.ParentId).HasName("PK__Parent__D339516FC9389632");

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
                        .HasConstraintName("FK__StudentPa__Stude__693CA210"),
                    l => l.HasOne<Parent>().WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentPa__Paren__6A30C649"),
                    j =>
                    {
                        j.HasKey("ParentId", "StudentId");
                        j.ToTable("StudentParent");
                    });
        });

        modelBuilder.Entity<ParentMeeting>(entity =>
        {
            entity.HasKey(e => e.MeetingId).HasName("PK__ParentMe__E9F9E94C08A41DE8");

            entity.ToTable("ParentMeeting");

            entity.Property(e => e.Decision).HasColumnType("text");
            entity.Property(e => e.Topic).HasColumnType("text");

            entity.HasOne(d => d.StudyGroup).WithMany(p => p.ParentMeetings)
                .HasForeignKey(d => d.StudyGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ParentMee__Study__4F7CD00D");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Person__AA2FFBE597DA8713");

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

        modelBuilder.Entity<SocialStatus>(entity =>
        {
            entity.HasKey(e => e.SocialStatusId).HasName("PK__SocialSt__B2D12E6BF892160F");

            entity.ToTable("SocialStatus");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasMany(d => d.Students).WithMany(p => p.SocialStatuses)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentSocialStatus",
                    r => r.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentSo__Stude__46E78A0C"),
                    l => l.HasOne<SocialStatus>().WithMany()
                        .HasForeignKey("SocialStatusId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentSo__Socia__47DBAE45"),
                    j =>
                    {
                        j.HasKey("SocialStatusId", "StudentId");
                        j.ToTable("StudentSocialStatus");
                    });
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.Abbreviation).HasName("PK__Speciali__9C41170F23D171DB");

            entity.ToTable("Specialization");

            entity.Property(e => e.Abbreviation).HasMaxLength(3);
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B99F0E696E7");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.IsExpelled).HasDefaultValue(false);

            entity.HasOne(d => d.StudentNavigation).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student__DateDed__30F848ED");

            entity.HasMany(d => d.Hobbies).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentHobby",
                    r => r.HasOne<Hobby>().WithMany()
                        .HasForeignKey("HobbyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentHo__Hobby__5DCAEF64"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentHo__Stude__5CD6CB2B"),
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
                        .HasConstraintName("FK__StudyGrou__PostI__5812160E"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudyGrou__Stude__571DF1D5"),
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
                        .HasConstraintName("FK__StudentSt__Study__4222D4EF"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentSt__Stude__412EB0B6"),
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
                .HasConstraintName("FK__StudentCl__Class__6477ECF3");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentClassHours)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentCl__Stude__6383C8BA");
        });

        modelBuilder.Entity<StudentInDormitory>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.Room });

            entity.ToTable("StudentInDormitory");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentInDormitories)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentIn__Stude__52593CB8");
        });

        modelBuilder.Entity<StudyGroup>(entity =>
        {
            entity.HasKey(e => e.StudyGroupId).HasName("PK__StudyGro__D97A1BE28A1CB00A");

            entity.ToTable("StudyGroup");

            entity.Property(e => e.DirectionAbbreviation).HasMaxLength(3);
            entity.Property(e => e.FullName)
                .HasMaxLength(11)
                .HasComputedColumnSql("((((([DirectionAbbreviation]+'-')+CONVERT([nvarchar](1),[Course]))+right(CONVERT([nvarchar](4),datepart(year,[DateCreate])),(2)))+isnull([SpecializationAbbreviation],''))+case when [IsBuget]=(0) then 'в' else '' end)", false);
            entity.Property(e => e.IsBuget).HasDefaultValue(true);
            entity.Property(e => e.SpecializationAbbreviation).HasMaxLength(3);

            entity.HasOne(d => d.DirectionAbbreviationNavigation).WithMany(p => p.StudyGroups)
                .HasForeignKey(d => d.DirectionAbbreviation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudyGrou__Direc__398D8EEE");

            entity.HasOne(d => d.SpecializationAbbreviationNavigation).WithMany(p => p.StudyGroups)
                .HasForeignKey(d => d.SpecializationAbbreviation)
                .HasConstraintName("FK__StudyGrou__Speci__3A81B327");
        });

        modelBuilder.Entity<TeacherCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__TeacherC__19093A0B31D36FCC");

            entity.ToTable("TeacherCategory");

            entity.Property(e => e.Name).HasMaxLength(33);
        });

        modelBuilder.Entity<Translation>(entity =>
        {
            entity.HasKey(e => new { e.LanguageCode, e.KeyName });

            entity.ToTable("Translation");

            entity.Property(e => e.LanguageCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.KeyName).HasMaxLength(25);
            entity.Property(e => e.Translation1)
                .HasMaxLength(50)
                .HasColumnName("Translation");

            entity.HasOne(d => d.KeyNameNavigation).WithMany(p => p.Translations)
                .HasForeignKey(d => d.KeyName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Translation_TranslationKey");

            entity.HasOne(d => d.LanguageCodeNavigation).WithMany(p => p.Translations)
                .HasForeignKey(d => d.LanguageCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Translation_Language");
        });

        modelBuilder.Entity<TranslationKey>(entity =>
        {
            entity.HasKey(e => e.KeyName);

            entity.ToTable("TranslationKey");

            entity.Property(e => e.KeyName).HasMaxLength(25);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4CBAD038D5");

            entity.ToTable("User");

            entity.Property(e => e.Login).HasMaxLength(30);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);

            entity.HasOne(d => d.Curator).WithMany(p => p.Users)
                .HasForeignKey(d => d.CuratorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Curator");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
