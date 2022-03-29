using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraining2
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<Pipe> fPipes = new FilteredElementCollector(doc, doc.ActiveView.Id)
                .OfCategory(BuiltInCategory.OST_PipeCurves)
                .WhereElementIsNotElementType()
                .Cast<Pipe>()
                .ToList();

            //XYZ pickedPoint = null;
            //try
            //{
            //    pickedPoint = uidoc.Selection.PickPoint(ObjectSnapTypes.Endpoints, "Выберите точку");
            //}
            //catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            //{}
            //if (pickedPoint == null)
            //{
            TaskDialog.Show("Количество труб", fPipes.Count.ToString());
            return Result.Succeeded;
            //}

            //TaskDialog.Show("Point info", $"X: {pickedPoint.X}, Y: {pickedPoint.Y}, Z: {pickedPoint.Z}");
            //return Result.Succeeded;
        }
    }

}
