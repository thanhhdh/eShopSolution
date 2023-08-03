var siteController = function () {
    this.initialize = function () {
        registerEvents()
        loadCart();
    }
    function loadCart() {
        const culture = $('#hidCulture').val();
        $.ajax({
            type: "GET",
            url: "/" + culture + "/cart/GetListItem",
            success: function (res) {
                $('#lbl_number_item').text(res.length);
            },
        })
    }
    function registerEvents() {
        $('body').on('click', '.btn-add-cart', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const culture = $('#hidCulture').val();
            $.ajax({
                type: "POST",
                url: "/" + culture + "/cart/AddToCart",
                data: {
                    id: id,
                    languageId: culture
                },
                success: function (res) {
                    $('#lbl_number_item').text(res.length);
                },
            })
        })

    }
}

function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}