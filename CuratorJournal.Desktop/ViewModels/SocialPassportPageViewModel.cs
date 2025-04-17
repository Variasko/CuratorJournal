using CuratorJournal.Desktop.Helpers;
using CuratorJournal.Desktop.Models;
using CuratorJournal.Desktop.ViewModels.Base;
using System.Collections.ObjectModel;

namespace CuratorJournal.Desktop.ViewModels
{
    internal class SocialPassportPageViewModel : BaseViewModel
    {
        #region CurrentCurator : Curator - Авторизованный куратор

        /// <summary> Авторизованный куратор </summary>
        private Curator _CurrentCurator = new Curator
        {
            CuratorId = 1,
            CategoryName = "Высшая категория",
            Person = new Person
            {
                PersonId = 1,
                Surname = "Comissarov",
                Name = "Alexander",
                Patronymic = "Alexeevich",
                Phone = "9128467",
                Email = "sakdjfh@gmail.com",
            },
            Groups = new List<Group>
            {
                new Group{ GroupId = 1, GroupFullName="ИСП-421п" }
            }
        };

        /// <summary> Авторизованный куратор </summary>
        public Curator CurrentCurator
        {
            get { return _CurrentCurator; }
            set
            {
                Set(ref _CurrentCurator, value);
            }
        }
        #endregion

        #region SosialPassports : ObservableCollection<SocialPassport> - Список студентов и их соцюстатусов

        /// <summary> Список студентов и их соцюстатусов </summary>
        private ObservableCollection<SocialPassport> _SocialPassports = new ObservableCollection<SocialPassport>
        {
            new SocialPassport 
            {
                SocialPassportId = 1,
                StudentName = "Комиссаров Александр Алексеевич",
                SocialStatus = "Малоимущий"
            }
        };

        /// <summary> Список студентов и их соцюстатусов </summary>
        public ObservableCollection<SocialPassport> SosialPassports
        {
            get { return _SocialPassports; }
            set
            {
                Set(ref _SocialPassports, value);
            }
        }
        #endregion


        #region AddLabel : string - Надпись на кнопке добавить

        /// <summary> Надпись на кнопке добавить </summary>
        private string _AddLabel = SettingsHelper.Instance.GetPhrase("Add");

        /// <summary> Надпись на кнопке добавить </summary>
        public string AddLabel
        {
            get { return _AddLabel; }
            set
            {
                Set(ref _AddLabel, value);
            }
        }
        #endregion
    }
}
