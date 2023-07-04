export default class grainApi {
  async text(url, data) {
    return fetch("https://localhost:7016/" + url, data)
      .then((response) => {
        const error = response.headers.get("error");
        if (error !== undefined && error !== null) {
          throw new ApiError(error);
        }
        if (response.status === 401) {
          localStorage.removeItem("token");
          throw new ApiError("401");
        }
        if (response.status > 401) {
          throw new ApiError("AccessError");
        }
        return response.text();
      })
      .catch((error) => {
        if (error.name === "ApiError") throw error;
        throw new ApiError("AccessError");
      });
  }

  formateBody(data) {
    return JSON.stringify(data);
  }

  async sendJsonFile(JsonFile) {
    fetch("https://localhost:7016/Grain/UploadDataFromJson", {
      method: "POST",
      headers: {
        Accept: "*/*",
        "Content-Type": "multipart/form-data",
      },
      body: JsonFile,
    }).then(
      function (response) {
        if (response.status != 201) {
          this.fetchError = response.status;
        } else {
          response.json().then(
            function (data) {
              this.fetchResponse = data;
            }.bind(this)
          );
        }
      }.bind(this)
    );
  }
  async getGrainData(OrderBy, Desc, PageSize, PageCount) {
    var responseG;
    await fetch("https://localhost:7016/Grain/GetGrainData", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: this.formateBody({
        OrderBy: OrderBy,
        Desc: Desc,
        PageSize: PageSize,
        PageCount: PageCount,
      }),
    })
      .then(function (response) {
        return response.json();
      })
      .then(function (text) {
        responseG = text;
      });
    return responseG;
  }
  async getGrainDataCount() {
    var responseC;
    await fetch("https://localhost:7016/Grain/GetGrainCount", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: this.formateBody({}),
    })
      .then(function (response) {
        return response.json();
      })
      .then(function (text) {
        responseC = text;
      });
    return responseC;
  }
  async deleteGrainData(rowsIds) {
    await fetch("https://localhost:7016/Grain/DeleteGrainData", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: this.formateBody({
        RowsIds: rowsIds,
      }),
    });
  }
  async getGrainDataGroups(GropeBy, PageSize, PageCount) {
    var responseG;
    await fetch("https://localhost:7016/Grain/GetDataGroups", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: this.formateBody({
        OrderBy: GropeBy,
        PageSize: PageSize,
        PageCount: PageCount,
      }),
    })
      .then(function (response) {
        return response.json();
      })
      .then(function (text) {
        responseG = text;
      });
    return responseG;
  }
  async GetDataMerged(GropeBy, PageSize, PageCount) {
    var responseG;
    await fetch("https://localhost:7016/Grain/GetDataMerged", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: this.formateBody({
        OrderBy: GropeBy,
        PageSize: PageSize,
        PageCount: PageCount,
      }),
    })
      .then(function (response) {
        return response.json();
      })
      .then(function (text) {
        responseG = text;
      });
    return responseG;
  }
  async MergeDataGroupsCount() {
    var responseC;
    await fetch("https://localhost:7016/Grain/MergeDataGroupsCount", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: this.formateBody({}),
    })
      .then(function (response) {
        return response.json();
      })
      .then(function (text) {
        responseC = text;
      });
    return responseC;
  }
  async SaveGrainInfo(
    RecordDate,
    BranchId,
    CropYear,
    CounterpartyId,
    CounterpartyName,
    ContractId,
    Product,
    Price,
    Amount,
    Process,
    Wetness,
    Garbage,
    Infection
  ) {
    await fetch("https://localhost:7016/Grain/SaveGrainInfo", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: this.formateBody({
        Amount: Amount,
        BranchId: BranchId,
        ContractId: ContractId,
        CounterpartyId: CounterpartyId,
        CounterpartyName: CounterpartyName,
        CropYear: CropYear,
        Garbage: Garbage,
        Infection: Infection,
        Price: Price,
        Process: Process,
        Product: Product,
        RecordDate: RecordDate,
        Wetness: Wetness,
      }),
    });
  }
  async EditGrainInfo(
    Id,
    RecordDate,
    BranchId,
    CropYear,
    CounterpartyId,
    CounterpartyName,
    ContractId,
    Product,
    Price,
    Amount,
    Process,
    Wetness,
    Garbage,
    Infection
  ) {
    await fetch("https://localhost:7016/Grain/EditGrainInfo", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: this.formateBody({
        Id: Id,
        Amount: Amount,
        BranchId: BranchId,
        ContractId: ContractId,
        CounterpartyId: CounterpartyId,
        CounterpartyName: CounterpartyName,
        CropYear: CropYear,
        Garbage: Garbage,
        Infection: Infection,
        Price: Price,
        Process: Process,
        Product: Product,
        RecordDate: RecordDate,
        Wetness: Wetness,
      }),
    });
  }
}
