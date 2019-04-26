using System;
using NXOpen;
using NXOpen.UF;

public class Nx_Wpf
{
    // class members
    private static Session theSession;
    private static UI theUI;
    private static UFSession theUfSession;
    public static Nx_Wpf theProgram;
    public static bool isDisposeCalled;

    //------------------------------------------------------------------------------
    // Constructor
    //------------------------------------------------------------------------------
    public Nx_Wpf()
    {
        try
        {
            theSession = Session.GetSession();
            theUI = UI.GetUI();
            theUfSession = UFSession.GetUFSession();
            isDisposeCalled = false;
        }
        catch (NXOpen.NXException ex)
        {
            UI.GetUI().NXMessageBox.Show("Message", NXMessageBox.DialogType.Error, ex.Message);
        }
    }

    //------------------------------------------------------------------------------
    //  Explicit Activation
    //      This entry point is used to activate the application explicitly
    //------------------------------------------------------------------------------
    //точка входа, запуск приложения в NX12 ctrl+u
    public static int Main(string[] args)
    {
        int retValue = 0;
        try
        {
            theProgram = new Nx_Wpf();

            //главное окно
            WPFNX.MainWindow dialog = new WPFNX.MainWindow();
            dialog.ShowDialog();
            theProgram.Dispose();
        }
        catch (NXOpen.NXException ex)
        {
            UI.GetUI().NXMessageBox.Show("Message", NXMessageBox.DialogType.Error, ex.Message);
        }
        return retValue;
    }

    static double[] map_abs_to_wcs(double[] abs_coords)
    {
        double[] work_coords = new double[3];

        theUfSession.Csys.MapPoint(UFConstants.UF_CSYS_ROOT_COORDS, abs_coords,
            UFConstants.UF_CSYS_ROOT_WCS_COORDS, work_coords);

        
        return work_coords;
    }

    public static double calculate_distance(double[] start_coords, double[] end_coords)
    {
        return Math.Sqrt(Math.Pow((end_coords[0] - start_coords[0]), 2.0) + Math.Pow((end_coords[1] - start_coords[1]), 2.0) + Math.Pow((end_coords[2] - start_coords[2]), 2.0));

    }

    public static bool SelectPoint(string message, ref double[] base_pt)
    {
        //Insert code here
        double[] work_coords = new double[3];

        if (select_point(message, ref base_pt) == UFConstants.UF_UI_OK)
        {
            //point_coords = base_pt;

            work_coords = map_abs_to_wcs(base_pt);
            base_pt = work_coords;
            return true;
        }



        /*    while (select_point("Select Point", ref base_pt) == UFConstants.UF_UI_OK)
            {
                theUI.NXMessageBox.Show(
                    "Selected Point",
                    NXMessageBox.DialogType.Information,
                    "X:" + base_pt[0].ToString() + "\nY:" + base_pt[1].ToString() + "\nZ:" + base_pt[2].ToString());
            }
            */
        return false;
    }

    private static int select_point(string cue, ref double[] base_pt)
    {
        NXOpen.Tag point_tag = NXOpen.Tag.Null;
        int response = 0;
        UFUi.PointBaseMethod base_method = UFUi.PointBaseMethod.PointInferred;

        theUfSession.Ui.LockUgAccess(NXOpen.UF.UFConstants.UF_UI_FROM_CUSTOM);
        theUfSession.Ui.PointConstruct(
                cue,
                ref base_method,
                out point_tag,
                base_pt,
                out response);
        theUfSession.Ui.UnlockUgAccess(NXOpen.UF.UFConstants.UF_UI_FROM_CUSTOM);
        return response;
    }



    //------------------------------------------------------------------------------
    // Following method disposes all the class members
    //------------------------------------------------------------------------------
    public void Dispose()
    {
        try
        {
            if (isDisposeCalled == false)
            {
                //TODO: Add your application code here 
            }
            isDisposeCalled = true;
        }
        catch (NXOpen.NXException ex)
        {
            // ---- Enter your exception handling code here -----

        }
    }
    //выгрузка программы сразу после выполнения
    public static int GetUnloadOption(string arg)
    {
        //Unloads the image immediately after execution within NX
        return System.Convert.ToInt32(Session.LibraryUnloadOption.Immediately);
    }

}

