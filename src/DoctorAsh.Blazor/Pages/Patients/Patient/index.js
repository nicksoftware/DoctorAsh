$(function () {

    var l = abp.localization.getResource('DoctorAsh');

    var service = doctorAsh.patients.patient;
    var createModal = new abp.ModalManager(abp.appPath + 'Patients/Patient/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Patients/Patient/EditModal');

    var dataTable = $('#PatientTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('DoctorAsh.Patient.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('DoctorAsh.Patient.Delete'),
                                confirmMessage: function (data) {
                                    return l('PatientDeletionConfirmationMessage', data.record.id);
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
                title: l('PatientAppointments'),
                data: "appointments"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewPatientButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
