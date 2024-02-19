var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {url : '/admin/product/getall'},
        "columns": [
            { data: 'title',"width" : "15%" },
            { data: 'description', "width": "15%" },
            { data: 'isbn', "width": "10%" },
            { data: 'author', "width": "10%" },
            { data: 'price', "width": "10%" },
            { data: 'category.name', "width": "15%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div>
                                <a href="/admin/product/upsert?id=${data}" class="btn btn btn-outline-primary"> <i class="bi bi-pencil"></i> Edit
                                </a>
                                <a href="" class="btn btn btn-outline-danger"> <i class="bi bi-x-square"></i> Delete
                                </a>
                    </div>`
                },
                "width": "25%"
            },
            
        ]
    });
}

