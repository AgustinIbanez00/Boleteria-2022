import { HttpResponse } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ViajesService } from 'src/app/viajes/viajes.service';
import { parserarErroresAPI } from '../utilidades';
import { webResultList } from '../webResult';

@Component({
  selector: 'app-select-viajes',
  templateUrl: './select-viajes.component.html',
  styleUrls: ['./select-viajes.component.css'],
})
export class SelectViajesComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    public viajesService: ViajesService
  ) {}

  @Input()
  form: FormGroup = this.formBuilder.group({});
  @Input()
  propiedad: string;
  @Input()
  validaciones: any;
  errores: string[] = [];
  viajes;

  ngOnInit(): void {}
}
