$(function () {
    bsCustomFileInput.init();
    $('table[data-table="true"]').DataTable({  //her sayfayı javascript ile kirletmemek için bu attributeyi kullanıcak
        "responsive": true,
        "autoWidth": false,
    });
    $('textarea[data-snote="true"]').summernote({
        height:200
    });

    // https://getbootstrap.com/docs/4.4/components/modal/#via-javascript
    $("body").on("click", "[data-delete-id]", function (event) { //body e tıklandığında esas tıklanan data-delete-id içeriyorsa bu function u çalıstırıcak delete sadece ilk sayfaya değil her yerde çalışabilcek
        event.preventDefault();// default davranışı önle href e basınca gitme
        var button = $(this); // Button that triggered the modal
        var id = button.data('delete-id') // Extract info from data-* attributes
        var name = button.data('delete-name') // Extract info from data-* attributes
        var action = button.data('delete-action') // Extract info from data-* attributes
        $("#deleteModalForm").attr("action", action);
        $("#deleteModalItemName").text(name);
        $("#deleteModalItemId").val(id);
        $("#deleteModal").modal();
    });
  
});