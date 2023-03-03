using System;
using System.Windows.Forms;
using ModelObject = GKHCalc.Models.Objects;
using GKHCalc.Forms;
using GKHCalc.Forms.Objects;
using GKHCalc.Forms.Objects.ChildForm;

namespace GKHCalc.Service.Helper
{
    public class FormHelper
    {
        public static bool GetIdGridTable(DataGridView dataGrid, out int objId)
        {
            objId = 0;
            if (dataGrid.SelectedCells.Count == 0)
            {
                MessageBox.Show("Выберете значение");
                return false;
            }
            int rowIndex = dataGrid.SelectedCells[0].RowIndex;
            string val = dataGrid.Rows[rowIndex].Cells[0].Value.ToString();
            if (!int.TryParse(val, out objId) && objId == 0)
            {
                MessageBox.Show("Выберете значение");
                return false;
            }
            return true;
        }

        public static object GetData(string MenuItem, int ObjectId = 0, string FieldForWhere = null) 
        {
            switch (MenuItem)
            {
                case "User":
                    return string.IsNullOrEmpty(FieldForWhere) ? ObjectService.GetAll(new ModelObject.User()) : ObjectService.GetsByWhere(new ModelObject.User(), FieldForWhere);
                case "Apartments":
                    return string.IsNullOrEmpty(FieldForWhere) ? ObjectService.GetAll(new ModelObject.Apartments()) : ObjectService.GetsByWhere(new ModelObject.Apartments(), FieldForWhere);
                case "House":
                    return string.IsNullOrEmpty(FieldForWhere) ? ObjectService.GetAll(new ModelObject.House()) : ObjectService.GetsByWhere(new ModelObject.House(), FieldForWhere);

                case "Rates":
                    return ObjectService.GetsByFieldId(new ModelObject.Rates(), "HouseId", ObjectId);
                case "Indicators":
                    return ObjectService.GetsByFieldId(new ModelObject.Indicators(), FieldForWhere, ObjectId);
                case "Payments":
                    return ObjectService.GetsByFieldId(new ModelObject.Payments(), FieldForWhere, ObjectId);
                case "RegisteredUser":
                    return ObjectService.GetsByFieldId(new ModelObject.RegisteredUser(), FieldForWhere, ObjectId);
                case "FillingMonth":
                    return ObjectService.GetsByFieldId(new ModelObject.FillingMonth(), FieldForWhere, ObjectId);
                case "IndebtednessApartment":
                    return ObjectService.GetsBalanceHouse(new ModelObject.BalanceHouse(), ObjectId);
            }
            return null;
        }

        public static void OpenModal(string MenuItem, int ObjectId, FormClosedEventHandler GetData, int parentId = 0, DateTime? dateTime = null)
        {
            Form form = new Form();
            switch (MenuItem)
            {
                case "User":
                    form = new User(ObjectId);
                    break;
                case "Apartments":
                    form = new Apartaments(ObjectId);
                    break;
                case "House":
                    form = new House(ObjectId);
                    break;



                case "Rates":
                    form = new Rates(ObjectId, parentId);
                    break;
                case "Indicators":
                    form = new Indicators(ObjectId, parentId);
                    break;
                case "Payments":
                    form = new Payments(ObjectId, parentId);
                    break;
                case "RegisteredUser":
                    form = new RegisteredUser(parentId);
                    break;
                case "FillingMonth":
                    form = new FillingMonth(ObjectId, parentId, dateTime: dateTime);
                    break;
            }
            form.Show();
            form.FormClosed += GetData;
        }

        public static void DeleteItem(DataGridView dataGrid, string MenuItem)
        {
            var dialogResult = MessageBox.Show("Вы уверены что хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (dialogResult.ToString() == "No" || (!FormHelper.GetIdGridTable(dataGrid, out int objId) && objId == 0))
                return;
            switch (MenuItem)
            {
                case "User":
                    ObjectService.Delete(new ModelObject.User(), objId);
                    break;
                case "Apartments":
                    ObjectService.Delete(new ModelObject.Apartments(), objId);
                    break;
                case "House":
                    ObjectService.Delete(new ModelObject.House(), objId);
                    break;
                case "Rates":
                    ObjectService.Delete(new ModelObject.Rates(), objId);
                    break;
                case "Indicators":
                    ObjectService.Delete(new ModelObject.Indicators(), objId);
                    break;
                case "Payments":
                    ObjectService.Delete(new ModelObject.Payments(), objId);
                    break;
                case "RegisteredUser":
                    ObjectService.Delete(new ModelObject.RegisteredUser(), objId);
                    break;
                case "FillingMonth":
                    ObjectService.Delete(new ModelObject.FillingMonth(), objId);
                    break;
            }
        }

        public static string GetGreetingByTime() 
        {
            var currentHour = DateTime.Now.Hour;
            if(currentHour >= 5 && 11 >= currentHour)
                return "Доброе утро";
            if (currentHour >= 12 && 15 >= currentHour)
                return "Добрый день";
            if (currentHour >= 15 && 23 >= currentHour)
                return "Добрый вечер";
            if (currentHour >= 0 && 4 >= currentHour)
                return "Доброй ночи";
            return null;
        }

        public static void ViewMessageGood(string message, string caption) 
        {
            MessageBox.Show(message,caption,MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        public static void ViewMessageError(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
