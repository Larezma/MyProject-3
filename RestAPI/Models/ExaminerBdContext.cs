using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models;

public partial class ExaminerBdContext : DbContext
{
    public ExaminerBdContext()
    {
    }

    public ExaminerBdContext(DbContextOptions<ExaminerBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Аудитории> Аудиторииs { get; set; }

    public virtual DbSet<ГрафикРаботы> ГрафикРаботыs { get; set; }

    public virtual DbSet<Группы> Группыs { get; set; }

    public virtual DbSet<Расписание> Расписаниеs { get; set; }

    public virtual DbSet<Экзаменаторы> Экзаменаторыs { get; set; }

    public virtual DbSet<Экзамены> Экзаменыs { get; set; }

    /*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-HUGFMTN;Database=ExaminerBD;User Id=mda;Password=12345; TrustServerCertificate=True;");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Аудитории>(entity =>
        {
            entity.HasKey(e => e.НомерАудитории);

            entity.ToTable("Аудитории");

            entity.Property(e => e.НомерАудитории)
                .HasMaxLength(32)
                .HasColumnName("номер_аудитории");
            entity.Property(e => e.КоличествоПосадочныхМест).HasColumnName("количество_посадочных_мест");
            entity.Property(e => e.ТипАудитории)
                .HasMaxLength(100)
                .HasColumnName("тип_аудитории");
        });

        modelBuilder.Entity<ГрафикРаботы>(entity =>
        {
            entity.HasKey(e => new { e.КодДисциплины, e.КодЭкзаменатора });

            entity.ToTable("График_работы");

            entity.Property(e => e.КодДисциплины).HasColumnName("код_дисциплины");
            entity.Property(e => e.КодЭкзаменатора).HasColumnName("код_экзаменатора");

            entity.HasOne(d => d.КодДисциплиныNavigation).WithMany(p => p.ГрафикРаботыs)
                .HasForeignKey(d => d.КодДисциплины)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_График_работы_Экзамены");

            entity.HasOne(d => d.КодЭкзаменатораNavigation).WithMany(p => p.ГрафикРаботыs)
                .HasForeignKey(d => d.КодЭкзаменатора)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_График_работы_Экзаменаторы");
        });

        modelBuilder.Entity<Группы>(entity =>
        {
            entity.HasKey(e => e.НомерГруппы);

            entity.ToTable("Группы");

            entity.Property(e => e.НомерГруппы)
                .HasMaxLength(32)
                .HasColumnName("номер_группы");
            entity.Property(e => e.КоличествоСтудентов).HasColumnName("количество_студентов");
            entity.Property(e => e.НомерКафедры).HasColumnName("номер_кафедры");
            entity.Property(e => e.Специальность)
                .HasMaxLength(100)
                .HasColumnName("специальность");
            entity.Property(e => e.СтаростаГруппы)
                .HasMaxLength(100)
                .HasColumnName("староста_группы");
            entity.Property(e => e.Факультет)
                .HasMaxLength(100)
                .HasColumnName("факультет");
        });

        modelBuilder.Entity<Расписание>(entity =>
        {
            entity.HasKey(e => new { e.КодДисциплины, e.КодЭкзаменатора, e.НомерГруппы, e.НомерАудитории });

            entity.ToTable("Расписание", tb =>
                {
                    tb.HasTrigger("TR_1");
                    tb.HasTrigger("TR_2");
                });

            entity.Property(e => e.КодДисциплины).HasColumnName("код_дисциплины");
            entity.Property(e => e.КодЭкзаменатора).HasColumnName("код_экзаменатора");
            entity.Property(e => e.НомерГруппы)
                .HasMaxLength(32)
                .HasColumnName("номер_группы");
            entity.Property(e => e.НомерАудитории)
                .HasMaxLength(32)
                .HasColumnName("номер_аудитории");

            entity.HasOne(d => d.НомерАудиторииNavigation).WithMany(p => p.Расписаниеs)
                .HasForeignKey(d => d.НомерАудитории)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Расписание_Аудитории");

            entity.HasOne(d => d.НомерГруппыNavigation).WithMany(p => p.Расписаниеs)
                .HasForeignKey(d => d.НомерГруппы)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Расписание_Группы");

            entity.HasOne(d => d.ГрафикРаботы).WithMany(p => p.Расписаниеs)
                .HasForeignKey(d => new { d.КодДисциплины, d.КодЭкзаменатора })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Расписание_График_работы");
        });

        modelBuilder.Entity<Экзаменаторы>(entity =>
        {
            entity.HasKey(e => e.КодЭкзаменатора);

            entity.ToTable("Экзаменаторы");

            entity.Property(e => e.КодЭкзаменатора)
                .ValueGeneratedNever()
                .HasColumnName("код_экзаменатора");
            entity.Property(e => e.Должность)
                .HasMaxLength(100)
                .HasColumnName("должность");
            entity.Property(e => e.Имя)
                .HasMaxLength(100)
                .HasColumnName("имя");
            entity.Property(e => e.НомерКафедры).HasColumnName("номер_кафедры");
            entity.Property(e => e.Отчество)
                .HasMaxLength(100)
                .HasColumnName("отчество");
            entity.Property(e => e.Фамилия)
                .HasMaxLength(100)
                .HasColumnName("фамилия");
        });

        modelBuilder.Entity<Экзамены>(entity =>
        {
            entity.HasKey(e => e.КодДисциплины);

            entity.ToTable("Экзамены");

            entity.Property(e => e.КодДисциплины)
                .ValueGeneratedNever()
                .HasColumnName("код_дисциплины");
            entity.Property(e => e.ДатаИВремяПроведения).HasColumnName("дата_и_время_проведения");
            entity.Property(e => e.НазваниеДисциплины)
                .HasMaxLength(100)
                .HasColumnName("название_дисциплины");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
