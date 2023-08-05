

var cartController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '.btn-plus', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($("#txt_quantity_" + id).val()) + 1;
            updateCart(id, quantity)
          
        })

        $('body').on('click', '.btn-minus', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($("#txt_quantity_" + id).val()) - 1;
            updateCart(id, quantity)
        })
        $('body').on('click', '.btn-remove', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            updateCart(id, 0)
        })

    }
    function updateCart(id, quantity) {
        const culture = $("#hidCulture").val();
        $.ajax({
            type: "POST",
            url: "/" + culture + "/cart/UpdateToCart",
            data: {
                id: id,
                quantity: quantity
            },
            success: function (res) {
                $('#lbl_number_item').text(res.length);
                loadData();
            },
        })
    }

    function loadData() {
        const culture = $('#hidCulture').val();
        $.ajax({
            type: "GET",
            url: "/" + culture + "/cart/GetListItem",
            success: function (res) {
                if (res.length == 0) {
                    $('#tbl_cart').hide();
                }
                var html = '';
                var total = 0;
                $.each(res, function (i, item) {
                    html += `<tr>
                  <td> <img width="60" src="${$('#hidBaseAddress').val() + item.image}" alt=""/></td>
                  <td>${item.description}</td>
				  <td>
					<div class="input-append">
                        <input class="span1" style="max-width:34px" placeholder="1" id="txt_quantity_${item.productId}" value="${item.quantity}" size="16" type="text">
                        <button class="btn btn-minus" data-id="${item.productId}" type="button"><i class="icon-minus"></i></button>
                        <button class="btn btn-plus" data-id="${item.productId}" type="button"><i class="icon-plus"></i></button>
                        <button class="btn btn-remove" data-id="${item.productId}" btn-danger" type="button"><i class="icon-remove icon-white"></i></button>				
                    </div>
				  </td>
                  <td>${numberWithCommas(item.price)}</td>

                  <td>${numberWithCommas(item.price * item.quantity)}</td>
                </tr>`;
                    total += item.price * item.quantity;
                });
                $('#cart_body').html(html);
                $('#lbl_total').text(numberWithCommas(total));
                $('#lbl_number_item').text(res.length);

            },
        })
    }
}