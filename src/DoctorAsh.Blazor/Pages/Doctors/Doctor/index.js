$(function () {

    var l = abp.localization.getResource('DoctorAsh');

    var service = doctorAsh.doctors.doctor;
    var createModal = new abp.ModalManager(abp.appPath + 'Doctors/Doctor/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Doctors/Doctor/EditModal');

    var dataTable = $('#DoctorTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('DoctorAsh.Doctor.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('DoctorAsh.Doctor.Delete'),
                                confirmMessage: function (data) {
                                    return l('DoctorDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: l('DoctorAppointments'),
                data: "appointments"
            },
            {
                title: l('DoctorWorkingHours'),
                data: "workingHours"
            },
            {
                title: l('DoctorStatus'),
                data: "status"
            },
            {
                title: l('DoctorRatingScore'),
                data: "ratingScore"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewDoctorButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
