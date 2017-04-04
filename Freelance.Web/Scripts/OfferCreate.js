$(function () {
    var urls = {
        OfferCreateUrl: "Offer/Create"
    };
    $('[data-toggle="popover"]').popover();
    var profileId;
    var OfferModal = {
        profileId: null,
        time: null,
        date: null,
        description: null,
        GetdData: function () {


        }

    };





    $('[data-offer-modal]').on('click', function () {
        profileId = $(this).attr("data-profile-id");
        $('#OfferCreate').modal('show');

    });

   

    $('#OfferCreate').on('hidden.bs.modal', function (e) {
            e.stopImmediatePropagation();
            $('[name="Time"]').val("");
            $('[name="Date"]').val(""),
            $('[name="Description"]').val("");
        });


    $('[data-bt-role="submit"]').on('click', function () {
        var data = {
            ProfileId:profileId,
            Time:$('[name="Time"]').val(),
            Date:$('[name="Date"]').val(),
            Description:$('[name="Description"]').val()
        };
        console.log(data.Time);
        
        $.post(urls.OfferCreateUrl, data)
            .success(function (suc) {
                console.log(suc);
                $('#OfferCreate').modal('hide');
            })
            .error(function (error) {

            console.log(error);
        });
       

    });
});