let ClsCategory =
{
    LoadCategories: function () {
        Helper.AjaxCallGet("/api/CategoryApi", {}, "json", function (data) {
            console.log(data);
            let htmlData = "";
            for (let i = 0; i < data.length; i++) {
                htmlData = htmlData + ClsCategory.Template2(data[i]);
            }

            $("#Categories").html(htmlData);
        },
            function () {

            });
    },
    Template2: function (cat) {
        let category = "";
        category += "<div class='my-2'><button onclick='ClsItems.FilterItems(" + cat.subCategoryId + ")' class='btn btn-lg btn-primary'>" + cat.subCategoryName + "</button></div>";
        return category;
    }
}
ClsCategory.LoadCategories();
