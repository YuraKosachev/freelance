$(function () {
    $('[data-offer-modal]').on('click', function () {
        var profileId = $(this).attr("data-profile-id");
        var modalId = $(this).attr("data-offer-modal");
        $(modalId).modal('show');

    });

});