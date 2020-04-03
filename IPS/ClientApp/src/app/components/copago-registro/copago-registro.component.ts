import { Component, OnInit } from '@angular/core';
import { CopagoService } from 'src/app/services/copago.service';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from "@angular/forms";
import { Copago } from 'src/app/models/copago';

@Component({
  selector: 'app-copago-registro',
  templateUrl: './copago-registro.component.html',
  styleUrls: ['./copago-registro.component.css']
})
export class CopagoRegistroComponent implements OnInit {

  copagoForm: FormGroup;
  formularioInvalido: boolean = false;
  guardado: boolean = null;

  constructor(private copagoService: CopagoService) { }

  ngOnInit(): void {
    this.copagoForm = this.createFormGroup();
  }

  createFormGroup() {
    return new FormGroup({
      Identificacion: new FormControl('', [Validators.required, Validators.maxLength(10), Validators.pattern("[0-9]+")]),
      Salario: new FormControl('', [Validators.required, Validators.min(0)]),
      ValorServicio: new FormControl('', [Validators.required, Validators.min(0)]),

    });
  }

  onSubmit() {
    if (this.copagoForm.valid) {
      let copago: Copago = new Copago();
      copago.identificacion = this.copagoForm.controls['Identificacion'].value;
      copago.salario = +this.copagoForm.controls['Salario'].value;
      copago.valorServicio = +this.copagoForm.controls['ValorServicio'].value;
      this.copagoService.post(copago).subscribe(copago => {
        if (copago != null)
          this.guardado = true;
        else this.guardado = false;
        setTimeout(() => {
          this.guardado = null;
          this.onReset();
        }, 3000);
      });
      this.formularioInvalido = false;
    } else this.formularioInvalido = true;
  }

  onReset() {
    this.copagoForm.reset();
    this.formularioInvalido = false;
  }

}
