var dataTable;

$(document).ready(function () {


    var url = window.location.search;
    var status;
    if (url.includes('Not%20Assigned')) {
        status = 'Not Assigned'
    } else if (url.includes('Wating%20Response')) {
        status = 'Wating Response'
    } else if (url.includes('In%20Process')) {
        status = 'In Process'
    } else if (url.includes('In%20Review')) {
        status = 'In Review';
    } else if (url.includes('Finished')) {
        status = 'Finished';
    }else {
        status = 'All'
    }
    loadDataTable(status);

});

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        
        "ajax": { url: '/admin/project/GetAll?status=' + status },
        "columns": [
            { data: 'name', "width": "20%" },
            { data: 'description', "width": "20%" },
            { data: 'cost', "width": "15%" },
            { data: 'creationDate', "width": "20%" },
            { data: 'status', "width": "20%" },
            { data: 'endDate', "width": "20%" },
            { data: 'services', "width": "20%" },
            { data: 'projectWorkers', "width": "20%" },

            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/project/Upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>
                     <a href="/admin/project/Upsert?id=${data}" class="btn btn-warning mx-2"> <i class="bi bi-list-task"></i> Tasks</a>
                     <a onClick= Delete('/admin/project/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
                },
                "width": "20%"
            }
        ]
    });

}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}