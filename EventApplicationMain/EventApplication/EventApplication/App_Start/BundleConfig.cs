using System.Web;
using System.Web.Optimization;

namespace EventApplication
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/RegistrationNgbundle").Include(
                        "~/AngularJS/jquery.js",
                        "~/AngularJS/jquery-ui.js",
                        "~/Angularlib/angular.js",
                        "~/Angularlib/angular-animate.js",
                        "~/Angularlib/angular-cookies.js",
                        "~/AngularJS/Module/App.js",
                        "~/AngularJS/Directive/Angudirective.js",
                        "~/AngularJS/AngularController/RegistrationController.js",
                        "~/AngularJS/AngularController/LoginController.js",
                        "~/AngularJS/OuterModule/igCharLimit.js",
                        "~/AngularJS/OuterModule/md5.js",
                        "~/AngularJS/OuterModule/loading-bar.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/AdminNgbundle").Include(
                          "~/Angularlib/angular.js",
                          "~/Angularlib/angular-animate.js",
                          "~/Angularlib/angular-cookies.js",
                          "~/Angularlib/angular-route.js",
                          "~/AngularJS/OuterModule/loading-bar.js",
                          "~/AngularJS/Module/App.js",
                          "~/AngularJS/Routing/AdminRoutingModule.js",
                          "~/AngularJS/AngularController/VenueController.js",
                          "~/AngularJS/AngularController/EquipmentController.js",
                          "~/AngularJS/AngularController/FoodController.js",
                          "~/AngularJS/AngularController/LightController.js",
                          "~/AngularJS/AngularController/FlowerController.js",
                          "~/AngularJS/AngularController/BookingApprovalController.js",
                          "~/AngularJS/AngularController/CustomerOrderDetailsController.js",
                          "~/AngularJS/OuterModule/trNgGrid.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/CustomerNgbundle").Include(
                        "~/AngularJS/jquery.js",
                        "~/AngularJS/jquery-ui.js",
                        "~/Angularlib/angular.js",
                        "~/Angularlib/angular-animate.js",
                        "~/Angularlib/angular-cookies.js",
                        "~/Angularlib/angular-route.js",
                        "~/AngularJS/OuterModule/loading-bar.js",
                        "~/AngularJS/Module/App.js",
                        "~/AngularJS/Routing/CustomerRoutingModule.js",
                        "~/AngularJS/Directive/Angudirective.js",
                        "~/AngularJS/AngularController/BookVenueController.js",
                        "~/AngularJS/AngularController/BookEquipmentController.js",
                        "~/AngularJS/AngularController/BookFoodController.js",
                        "~/AngularJS/AngularController/BookLightController.js",
                        "~/AngularJS/AngularController/BookFlowerController.js",
                        "~/AngularJS/AngularController/TotalReceiptController.js",
                        "~/AngularJS/AngularController/BookingDetailsController.js",
                        "~/AngularJS/AngularController/OrderDetailsController.js",
                        "~/AngularJS/OuterModule/igCharLimit.js",
                        "~/AngularJS/OuterModule/angularPrint.js",
                        "~/AngularJS/OuterModule/trNgGrid.js"
              ));



            bundles.Add(new StyleBundle("~/CustomerContent/css").
                Include(
                "~/Content/themes/base/jquery-ui.css",
                "~/bootstrap/css/bootstrap.css",
                "~/Content/Gallery.css",
                "~/Content/angularPrint.css",
                "~/Content/trNgGrid.min.css",
                "~/Content/loading-bar.css"
                ));

            bundles.Add(new StyleBundle("~/AdminContent/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}