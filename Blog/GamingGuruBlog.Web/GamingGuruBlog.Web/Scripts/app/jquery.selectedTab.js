$('#myTab a').click(function(e){
    e.preventDefault();
    $(this).tab('show');
});

// this sets the selected tabs valeu in the window location hash value 
$("ul.nav-tabs > li > a").on("shown.bs.tab", function(e){
    var id = $(e.target).attr("href").substr(1);
    window.location.hash = id;
});

var hash = window.location.hash;
$('#myTab a[href="' + hash + '"]').tab('show');