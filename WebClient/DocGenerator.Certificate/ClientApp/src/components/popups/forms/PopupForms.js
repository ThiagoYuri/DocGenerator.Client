import React, {  Component } from 'react';
import './PopupForms.css'

export class PopupForms extends Component {

    constructor(props) {
        super(props);
        this.createCertificate = this.createCertificate.bind(this)
    }

    seachDocument(id) {
        window.open('http://localhost:5000/DocumentWord/GetFile?id=' + id);
    }


    createCertificate() {
        const { course } = this.props;
        const nameFull = document.getElementById("inputNameFull").value;
        if (nameFull.length > 5) {
            fetch('certificate?nameCourse=' + course.NameCourse + '&nameFullUser=' + nameFull, { method: 'POST', headers: { "Content-type": "application/json;charset=UTF-8" } })
                .then(response => response.json())  // convert to json
                .then(json => this.seachDocument(json))    // print console
                .catch(err => alert('Erro:'+err));
        } else {
            alert("Name is invalid");
        }
        
    }

    render() {
        return (
            //Modal
            <div className="collapse show modal fade PopupForms" tabIndex="-1" style={{display:'block'}}>
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title" id="exampleModalLabel">Full Name</h5>
                        </div>
                        <div className="modal-body">
                            <div className="input-group">
                                <span className="input-group-text">Full Name</span>
                                <input type="text" id="inputNameFull" className="form-control" placeholder="Example: Thiago Yuri Oliveira Monteiro" aria-label="Username" />
                            </div>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-secondary" onClick={this.props.closePopup}>Close</button>
                            <button type="button" className="btn btn-primary" onClick={this.createCertificate}>Save changes</button>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
