import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddlogComponent } from './addlog.component';

describe('AddlogComponent', () => {
  let component: AddlogComponent;
  let fixture: ComponentFixture<AddlogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddlogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddlogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
