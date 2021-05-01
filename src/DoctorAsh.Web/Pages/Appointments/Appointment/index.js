$(function () {

    var l = abp.localization.getResource('DoctorAsh');

    var service = doctorAsh.appointments.appointment;
    var createModal = new abp.ModalManager(abp.appPath + 'Appointments/Appointment/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Appointments/Appointment/EditModal');

    var dataTable = $('#AppointmentTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('DoctorAsh.Appointment.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('DoctorAsh.Appointment.Delete'),
                                confirmMessage: function (data) {
                                    return l('AppointmentDeletionConfirmationMessage', data.record.id);
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
                title: l('AppointmentTitle'),
                data: "title"
            },
            {
                title: l('AppointmentDescription'),
                data: "description"
            },
            {
                title: l('AppointmentStartDate'),
                data: "startDate"
            },
            {
                title: l('AppointmentEndDate'),
                data: "endDate"
            },
            {
                title: l('AppointmentRecurrence'),
                data: "recurrence"
            },
            {
                title: l('AppointmentStatus'),
                data: "status"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewAppointmentButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
