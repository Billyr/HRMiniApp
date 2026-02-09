//using DevExpress.ExpressApp.Blazor.Editors.Adapters;
//using Microsoft.AspNetCore.Components;
//using System.Globalization;

//namespace BusinessSuite.Xaf.Blazor.Server.Editors.MonthYearPicker
//{
//    public partial class MonthYearPicker : ComponentBase
//    {
//        [Parameter] public bool IsReadOnly { get; set; }
//        [Parameter] public string ErrorMessage { get; set; }
//        [Parameter] public DateTime? Value { get; set; }
//        [Parameter] public EventCallback<DateTime?> ValueChanged { get; set; }
//        [Parameter] public MonthYearAdapter Adapter { get; set; }

//        protected bool PopupVisible;
//        protected int SelectedMonth = 1;
//        protected int Year = DateTime.Today.Year;

//        protected override void OnInitialized()
//        {
//            base.OnInitialized();

//            if (Adapter != null)
//            {
//                //Adapter.SetStateHasChangedCallback(() => InvokeAsync(StateHasChanged));
//            }
//        }

//        protected override void OnParametersSet()
//        {
//            base.OnParametersSet();
//            RefreshFromValue();
//        }

//        private void RefreshFromValue()
//        {
//            if (Value.HasValue && Value.Value.Year >= 1900)
//            {
//                SelectedMonth = Value.Value.Month;
//                Year = Value.Value.Year;
//            }
//            else
//            {
//                SelectedMonth = DateTime.Today.Month;
//                Year = DateTime.Today.Year;
//            }
//        }

//        protected override void OnAfterRender(bool firstRender)
//        {
//            base.OnAfterRender(firstRender);
//            if (firstRender && Adapter != null)
//            {
//                //   Adapter.NotifyComponentReady();
//            }
//        }

//        protected string DisplayText =>
//            (Value.HasValue && Value.Value.Year >= 1900)
//                ? Value.Value.ToString("MMMM yyyy", CultureInfo.CreateSpecificCulture("es-MX"))
//                : "Seleccionar";

//        protected List<(int Index, string Name)> Months { get; } = new List<(int Index, string Name)>
//        {
//            (1, "Enero"), (2, "Febrero"), (3, "Marzo"), (4, "Abril"),
//            (5, "Mayo"), (6, "Junio"), (7, "Julio"), (8, "Agosto"),
//            (9, "Septiembre"), (10, "Octubre"), (11, "Noviembre"), (12, "Diciembre")
//        };

//        protected void OpenPopup()
//        {
//            if (IsReadOnly) return;
//            RefreshFromValue();
//            PopupVisible = true;
//        }

//        protected void SelectMonth(int month)
//        {
//            SelectedMonth = month;
//            StateHasChanged();
//        }



//        [Parameter] public EventCallback<DateTime> OnConfirmed { get; set; }

//        protected async Task ConfirmAsync()
//        {
//            var date = new DateTime(Year, SelectedMonth, 1).Date;
//            Console.WriteLine($"MonthYearPicker - ConfirmAsync - Fecha creada: {date}");

//            await OnConfirmed.InvokeAsync(date);
//            PopupVisible = false;
//        }

//        protected void Cancel()
//        {
//            PopupVisible = false;
//            RefreshFromValue();
//        }

//        protected void IncrementYear()
//        {
//            if (Year < 2100)
//            {
//                Year++;
//                StateHasChanged();
//            }
//        }

//        protected void DecrementYear()
//        {
//            if (Year > 1900)
//            {
//                Year--;
//                StateHasChanged();
//            }
//        }
//    }
//}