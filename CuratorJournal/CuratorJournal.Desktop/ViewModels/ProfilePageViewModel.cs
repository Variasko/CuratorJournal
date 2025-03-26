using CuratorJournal.Desktop.Helpers;
using CuratorJournal.Desktop.ViewModels.Base;

namespace CuratorJournal.Desktop.ViewModels
{
    internal class ProfilePageViewModel : BaseViewModel
    {

		#region Surname : string - Фамилия вошедшего куратора

		/// <summary> Фамилия вошедшего куратора </summary>
		private string _Surname;

		/// <summary> Фамилия вошедшего куратора </summary>
		public string Surname
		{
			get { return _Surname; }
			set { Set(ref _Surname, value); }
		}
		#endregion

		#region Name : string - Имя вошедшего куратора

		/// <summary> Имя вошедшего куратора </summary>
		private string _Name;

		/// <summary> Имя вошедшего куратора </summary>
		public string Name
		{
			get { return _Name; }
			set { Set(ref _Name, value); }
		}
		#endregion

		#region Patronymic : string - Отчество вошедшего куратора

		/// <summary> Отчество вошедшего куратора </summary>
		private string _Patronymic;

		/// <summary> Отчество вошедшего куратора </summary>
		public string Patronymic
		{
			get { return _Patronymic; }
			set { Set(ref _Patronymic, value); }
		}
		#endregion


		#region CategoryName : string - Категория куратора

		/// <summary> Категория куратора </summary>
		private string _CategoryName;

		/// <summary> Категория куратора </summary>
		public string CategoryName
		{
			get { return _CategoryName; }
			set { Set(ref _CategoryName, value); }
		}
		#endregion


		#region LogOutToolTip : string - Подсказка на выход

		/// <summary> Подсказка на выход </summary>
		private string _LogOutToolTip = SettingsHelper.Instance.GetPhrase("Logout");

		/// <summary> Подсказка на выход </summary>
		public string LogOutToolTip
		{
			get { return _LogOutToolTip; }
			set { Set(ref _LogOutToolTip, value); }
		}
		#endregion

		public ProfilePageViewModel()
		{

		}
	}
}
