import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GetWordsComponent } from './get-words.component';

describe('GetWordsComponent', () => {
  let component: GetWordsComponent;
  let fixture: ComponentFixture<GetWordsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetWordsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GetWordsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
