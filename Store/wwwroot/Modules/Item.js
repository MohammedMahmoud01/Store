let Items = [];

let ClsItems =
{
    LoadItems: function () {
        Helper.AjaxCallGet("/api/itemsapi", {}, "json", function (data) {
            //console.log(data);
            Items = data;
            let htmlData = "";
            for (let i = 0; i < data.length; i++) {
                htmlData = htmlData + ClsItems.Template1(data[i]);
            }

            $("#DivTemplate1").html(htmlData);
        },
            function () {

            });
    },
    Template1: function (item) {
        let itemHtml = "";
        itemHtml += '<div class="col-xl-3 col-6 col-grid-box"> \
            <div class="product-box" > \
                <div class="img-wrapper"> \
                    <div class="front"> \
                        <a href="/Home/ItemDetails/'+ item.itemId + '"><img src="/Uploads/'+ item.imageName + '" style="width: 100% ; height:200px" alt=""></a>\
                                                        </div>\
                        <div class="back">\
                            <a href="/Home/ItemDetails/'+ item.itemId + '"><img src="/Uploads/'+ item.imageName + '" style="width: 100% ; height:200px" alt=""></a>\
                                                        </div>\
                            <div class="cart-info cart-wrap">\
                                <a href="/Home/ItemDetails/'+ item.itemId + '">\
                                    <i class="ti-shopping-cart"></i>\
                                                                    </a >\
                                    <a href="/Home/ItemDetails/'+ item.itemId + '" \
                                        title="Add to Wishlist">\
                                        <i class="ti-heart" aria-hidden="true"></i>\
                                    </a>\
                                    </div >\
                            </div>\
                        <div class="product-detail">\
                            <div>\
                                <div class="rating"><i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i></div>\
                                <a >\
                                    <h6>'+ item.itemName + '</h6>\
                                </a>\
                                <p>\
                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley\
                                    of type and scrambled it to make a type specimen book\
                                </p>\
                                <h4>$'+ item.salesPrice + '</h4>\
                            </div>\
                        </div>\
                    </div>\
                </div>' ;

        return itemHtml;
    }
    ,
    FilterItems: function (catId) {
        let newItems = $.grep(Items, function (n, i) { // just use arr
            return n.subCategoryId === catId;
        });
        //console.log(newItems);
        let htmlData = "";
        for (let i = 0; i < newItems.length; i++) {
            htmlData = htmlData + ClsItems.Template1(newItems[i]);
        }
        $("#DivTemplate1").html(htmlData);
    }
}

ClsItems.LoadItems();
