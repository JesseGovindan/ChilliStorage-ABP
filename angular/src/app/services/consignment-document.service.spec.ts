import { TestBed } from '@angular/core/testing';

import { ConsignmentDocumentService } from './consignment-document.service';

describe('ConsignmentDocumentService', () => {
  let service: ConsignmentDocumentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConsignmentDocumentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
