import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styles: [
  ]
})
export class FilterComponent implements OnInit {
  public filterForm: FormGroup;
  public departments: Deparment[] = [];
  private url: string;


  constructor(
    private router: Router,
    private http:HttpClient,
    private fb: FormBuilder,
     @Inject('BASE_URL') baseUrl: string) {
      this.url = baseUrl+"api/department"
    this.filterForm = this.fb.group({
      'name': [null, Validators.required],
      'department': ["Select...", Validators.required],
      'education': [null, Validators.required],
      'score': [null, Validators.required],
      'arrowScore': ["Current", Validators.required],
      'birthYaer': [null, Validators.required],
      'arrowBirth': ["Current", Validators.required],

      'nameSort': [null, Validators.required],
      'departmentSort': [null, Validators.required],
      'educationSort': [null, Validators.required],
      'scoreSort': [null, Validators.required],
      'birthYearSort': [null, Validators.required],

      'isMine':[false,Validators.required]
    });

  }

  ngOnInit(): void {
    this.http.get(this.url + "/all").subscribe(data =>
      {
        console.log(data);
       this.departments = data['departmentList'];
      } )
  }
  onFilter() {
    this.checkOptionField();
    let searchResult=Object.entries(this.filterForm.value)
                          .filter(([k,v])=>v!=null)
                          .reduce((acc, [k, v]) => ({ ...acc, [k]: v }), {});
console.log(searchResult );
    this.router.navigate(['/'], { queryParams: { "query": "filter " + JSON.stringify(
      searchResult)
  }});}

  checkOptionField() {
    this.filterForm.value['department'] = this.filterForm.value['department'] == "Select..."
      ? null
      : this.filterForm.value['department'];
    this.filterForm.value['arrowScore'] = this.filterForm.value['arrowScore'] == "Current"
      ? null
      : this.filterForm.value['arrowScore'];
    this.filterForm.value['arrowBirth'] = this.filterForm.value['arrowBirth'] == "Current"
      ? null
      : this.filterForm.value['arrowBirth'];
  }
  get name() { return this.filterForm.get('name') }
  get department() { return this.filterForm.get('department') }
  get education() { return this.filterForm.get('education') }
  get score() { return this.filterForm.get('score') }
  get arrowScore() { return this.filterForm.get('arrowScore') }
  get birthYaer() { return this.filterForm.get('birthYaer') }
  get arrowBirth() { return this.filterForm.get('arrowBirth') }

  get nameSort() { return this.filterForm.get('nameSort') }
  get departmentSort() { return this.filterForm.get('departmentSort') }
  get educationSort() { return this.filterForm.get('educationSort') }
  get scoreSort() { return this.filterForm.get('scoreSort') }
  get birthYearSort() { return this.filterForm.get('birthYearSort') }

  get isMine() { return this.filterForm.get('isMine') }
}

export interface Deparment {
  name: string
}