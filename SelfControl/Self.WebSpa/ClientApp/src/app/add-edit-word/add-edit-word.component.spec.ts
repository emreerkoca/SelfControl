import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditWordComponent } from './add-edit-word.component';

describe('AddEditWordComponent', () => {
  let component: AddEditWordComponent;
  let fixture: ComponentFixture<AddEditWordComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddEditWordComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditWordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
