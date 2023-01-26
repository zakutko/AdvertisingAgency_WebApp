import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApproverPanelComponent } from './approver-panel.component';

describe('ApproverPanelComponent', () => {
  let component: ApproverPanelComponent;
  let fixture: ComponentFixture<ApproverPanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApproverPanelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApproverPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
